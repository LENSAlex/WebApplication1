using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Classes
{
    public class Config
    {
        private static IConfigurationRoot _configuration;

        static Config()
        {

            ConfigurationBuilder _configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            _configurationBuilder.AddJsonFile(path, false);

            _configuration = _configurationBuilder.Build();
        }

        //Récupère une valeur du fichier de configuration (attend une clé en paramètre)
        public static string GetConfig(string key)
        {
            return _configuration.GetSection(key).Value;
        }

        //Retourne la chaîne de connection à la base de données
        public static string ConnectionString
        {
            get => GetConfig("ConnectionStrings:MainDatabase");
        }
    }
}
