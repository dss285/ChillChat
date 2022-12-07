using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeon.Core
{
    public static class ExtensionUtils
    {

        public static IConfigurationBuilder AddJsonStringToConfiguration(this IConfigurationBuilder configuration, string jsonString)
        {
            using MemoryStream ms = new();
            using StreamWriter writer = new(ms);
            writer.Write(Encoding.UTF8.GetBytes(jsonString));
            configuration = configuration.AddJsonStream(ms);
            return configuration;
        }
    }
}
