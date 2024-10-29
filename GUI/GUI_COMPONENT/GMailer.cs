using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GUI.GUI_COMPONENT
{
    public class GMailer
    {
        private string SenderEmail;
        private string SenderName;
        private string ReceivedEmail;
        private string ReceivedName;
        private GmailService service;

        private GMailer()
        {
            // Gọi hàm khởi tạo Gmail Service
            InitializeGmailerAsync();
        }

        private static GMailer instance;
        public static GMailer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GMailer();
                }
                return instance;
            }
        }

        private async Task InitializeGmailerAsync()
        {
            FirebaseService firebaseService = new FirebaseService();
            string clientId = await firebaseService.GetAsync<string>(new []{ "GmailAPI", "client_id"});
            string clientSecret = await firebaseService.GetAsync<string>(new[] { "GmailAPI", "client_secret"});

            string tokenPath = Path.Combine(Directory.GetCurrentDirectory(), "tokens");
            Directory.CreateDirectory(tokenPath);

            string fileName = await firebaseService.GetAsync<string>(new[] { "GmailAPI", "token_file", "name" });
            string fullPath = Path.Combine(tokenPath, fileName);
            string fileValue = await firebaseService.GetAsync<string>(new[] { "GmailAPI", "token_file", "value" });

            if (!File.Exists(fullPath))
            {
                File.WriteAllText(fullPath, fileValue);
                Console.WriteLine("Token file created.");
            }


            UserCredential credential = await GetCredentials(clientId, clientSecret);

            this.service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Hotel Luxury"
            });
        }

        private async Task<UserCredential> GetCredentials(string clientID, string clientSecret)
        {
            string credPath = "tokens";
            ClientSecrets secrets = new ClientSecrets
            {
                ClientId = clientID,
                ClientSecret = clientSecret
            };
            return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                secrets,
                new[] { GmailService.Scope.GmailSend },
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true));
        }

        public async Task SendMail(string senderEmail, string senderName, string receivedEmail, string receivedName, string subject, string messageBody)
        {
            SenderEmail = senderEmail;
            SenderName = senderName;
            ReceivedEmail = receivedEmail;
            ReceivedName = receivedName;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(SenderName, SenderEmail));
            message.To.Add(new MailboxAddress(ReceivedName, ReceivedEmail));
            Console.WriteLine(ReceivedEmail);
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = messageBody
            };

            using (var memoryStream = new MemoryStream())
            {
                message.WriteTo(memoryStream);
                var rawMessage = Convert.ToBase64String(memoryStream.ToArray())
                    .Replace("+", "-")
                    .Replace("/", "_")
                    .Replace("=", "");

                var gmailMessage = new Message
                {
                    Raw = rawMessage
                };

                try
                {
                    var result = await service.Users.Messages.Send(gmailMessage, "me").ExecuteAsync();
                    Console.WriteLine("Message sent. ID: " + result.Id);
                }
                catch (Google.GoogleApiException ex) when (ex.HttpStatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("Unable to send message: " + ex.Message);
                }
            }
        }
    }
}
