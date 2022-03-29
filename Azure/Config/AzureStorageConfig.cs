using Microsoft.Extensions.Configuration;
using System;

namespace APL_Technical_Test.Azure.Config
{
    public static class AzureStorageConfig
    {
        private static IConfiguration currentConfig;

        public static void SetConfig(IConfiguration configuration)
        {
            currentConfig = configuration;
        }


        public static string GetConfiguration(string configKey)
        {
            try
            {
                string connectionString = currentConfig.GetConnectionString(configKey);
                return connectionString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }
    }
}
