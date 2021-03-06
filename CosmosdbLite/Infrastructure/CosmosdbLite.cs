﻿using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosdbLite
{
    public sealed class CosmosdbLite
    {
        private static CosmosdbLite mInstance;
        private static Object mLock = new object();

        private static string endpoint;
        private static string key;

        public string DatabaseName { get; }
        public string ContainerName { get; }

        public DocumentClient DClient { get; }

        private CosmosdbLite()
        {
            throw new Exception("It should never be called!");
        }

        private CosmosdbLite(string databaseeName, string containerName)
        {
            DatabaseName = databaseeName;
            ContainerName = containerName;

            endpoint = GetCosmosDbConfig("endpoint");
            key = GetCosmosDbConfig("key");
            DClient = new DocumentClient(new Uri(endpoint), key);
        }

        public static CosmosdbLite Instance
        {
            get
            {
                if (mInstance == null)
                {
                    throw new Exception("The instance isn't created yet!");
                }

                return mInstance;
            }
        }

        public static CosmosdbLite Create(string databaseeName, string containerName)
        {
            lock(mLock)
            {
                if (mInstance != null)
                {
                    return mInstance;
                }

                return mInstance = new CosmosdbLite(databaseeName, containerName);
            }
        }

        private static string GetCosmosDbConfig(string key)
        {
            if (key.Equals("endpoint") && !string.IsNullOrEmpty(endpoint)) {
                return endpoint;
            }
            else if (key.Equals("key") && !string.IsNullOrEmpty(key))
            {
                return key;
            }

            try
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;

                string[] values = appSettings.GetValues(key);
                return values[0];
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine(e.ToString());
                return string.Empty;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return string.Empty;
            }
        }
    }
}
