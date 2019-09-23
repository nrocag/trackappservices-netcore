namespace TrackAppServices.DataBase
{
    using System;
    using System.Threading.Tasks;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.Azure.Cosmos;
    using MongoDB.Driver;
    using System.Security.Authentication;

    public class ConnectionCosmosMongoDb
    {
        private static readonly string connectionString = @"mongodb://cosmodb-tests:a013ZLyCStwKuS3wVAFgaxHQWlhvPnx6Tu774PMGQqrl7VEnmGhfrRBIjafNcF5th2Gv5UqhZOoCGEAuDlZxLw==@cosmodb-tests.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        private static IMongoDatabase dataBase;

        public static IMongoDatabase DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    GetDataBase();
                }

                return dataBase;
            }
        }

        private static void GetDataBase()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            MongoClient mongoClient = new MongoClient(settings);

            dataBase = mongoClient.GetDatabase("TrackApp_FullStack");
        }
    }

    
}
