using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace GUI.GUI_COMPONENT
{
    public class FirebaseService
    {
        private IFirebaseConfig config;// = new FirebaseConfig
        //{
        //    AuthSecret = "luxury-hotel-bot-default-rtdb\tWNQonGJ7J8p2bTY1btsOd8RR5MrxeZDYbFQKrEDK",
        //    BasePath = "https://luxury-hotel-bot-default-rtdb.asia-southeast1.firebasedatabase.app/"
        //};
        private IFirebaseClient client;
        private readonly FirebaseClient firebaseClient;

        // Khởi tạo FirebaseService với URL của Firebase Database
        public FirebaseService()
        {
            DotNetEnv.Env.Load();
            string authSecret = Environment.GetEnvironmentVariable("FIREBASE_AUTH_SECRET");
            string basePath = Environment.GetEnvironmentVariable("FIREBASE_BASE_PATH");
            config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath
            };

            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                Console.WriteLine("Firebase connection established.");
            }
            else
            {
                Console.WriteLine("Firebase connection failed.");
            }
        }

        public async Task<T> GetAsync<T>(string[] keys)
        {
            string path = string.Join("/", keys);
            FirebaseResponse response = await client.GetAsync(path);
            return response.ResultAs<T>();
        }

    }
}
