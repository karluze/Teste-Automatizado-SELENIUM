using System.IO;
using Microsoft.Extensions.Configuration;
using selenium;
using Xunit;

namespace contatosTestes.classesBase
{
    public abstract class BaseTest
    {
        public IConfiguration _configuration;
        public string emailPadrão { get; set; }
        public string senhaEmailPadrão { get; set; }

        public BaseTest()
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            emailPadrão = "selenium@mail.com";
            senhaEmailPadrão = "Mudar@123";
        }

        public void Login(Browser browser, string email, string senha)
        {
            RegistrarLogin login = new RegistrarLogin(_configuration, browser);
            login.CarregarPagina();
            var usuarioLogado = login.Login(email, senha);

            Assert.NotEmpty(usuarioLogado);
            var existe = usuarioLogado.Contains(email);
            Assert.True(existe);
        }
    }
}
