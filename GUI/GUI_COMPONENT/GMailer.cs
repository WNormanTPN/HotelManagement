using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        private readonly GmailService service;

        public GMailer(string senderEmail, string senderName, string receivedEmail, string receivedName)
        {
            SenderEmail = senderEmail;
            SenderName = senderName;
            ReceivedEmail = receivedEmail;
            ReceivedName = receivedName;

            var credentialPath = "../../../gmailAPI.json";
            var credential = GetCredentials(credentialPath).Result;

            service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Hotel Luxury"
            });
        }

        private async Task<UserCredential> GetCredentials(string credentialPath)
        {
            using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
            {
                string credPath = "tokens";
                return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { GmailService.Scope.GmailSend },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));
            }
        }

        public async Task SendMail(string subject, string messageBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(SenderName, SenderEmail));
            message.To.Add(new MailboxAddress(ReceivedName, ReceivedEmail));
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