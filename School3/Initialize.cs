using Microsoft.Extensions.Configuration;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School3
{
    public class Initialize
    {
        private static IConfigurationRoot GetConfiguration(Assembly assembly)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");

            var configuration = configurationBuilder.Build();
            return configuration;
        }

        public static string GetConnectionString()
        {
            var configuration = GetConfiguration(Assembly.GetExecutingAssembly());
            return configuration["ConnectionStrings:sqlserver"];
        }
    }
}
