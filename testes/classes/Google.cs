using System;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using selenium;

namespace testes.classes
{
    public class Google : BaseClass
    {
        public Google(IConfiguration configuration, Browser browser) : base(configuration, browser)
        {
        }

        public void CarregarPagina()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("http://www.google.com.br");
        }

        public ReadOnlyCollection<IWebElement> BuscaGoogle(string conteudo)
        {
            IWebElement webElement = _driver.FindElement(By.Name("q"));
            webElement.SendKeys(conteudo);
            webElement.SendKeys(Keys.Enter);

            _driver.Esperar(By.Id("search"), TimeSpan.FromSeconds(5));

            IWebElement resultsSearch = _driver.FindElement(By.Id("search"));
            return resultsSearch.FindElements(By.XPath(".//a"));
        }

        public void FecharPagina()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
