using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using selenium;
using testes;
using testes.classes;
using Xunit;

namespace Testes.casosTestes
{
    public class TestePesquisaGoogle : BaseTest
    {
        public TestePesquisaGoogle() { }

        [Fact]
        public void TestarFireFox()
        {
            ExecutaTesteGoogle(Browser.FireFox);
        }

        [Fact]
        public void TestarChrome()
        {
            ExecutaTesteGoogle(Browser.Chrome);
        }

        private void ExecutaTesteGoogle(Browser browser)
        {
            Google testeGoogle = new Google(_configuration, browser);
            testeGoogle.CarregarPagina();
            var results = testeGoogle.BuscaGoogle("mfrinfo");
            foreach (IWebElement result in results)
            {
                Console.WriteLine(result.Text);
            }
            Assert.True(results.Count > 0);
            testeGoogle.FecharPagina();
        }
    }
}
