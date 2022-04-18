using System.IO;
using Microsoft.Extensions.Configuration;

namespace testes
{
    public abstract class BaseTest
    {
        public IConfiguration _configuration;
        public BaseTest()
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }

    }
}
