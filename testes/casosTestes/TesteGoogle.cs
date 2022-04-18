using OpenQA.Selenium;
using testes;

namespace Testes.casosTestes
{
    public class TesteGoogle : BaseTest
    {
        private IWebDriver _driver;
        public TesteGoogle(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void AbrirPaginaGoogle()
        {
            _driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl("http://www.google.com.br");
        }

        public void FecharPaginaGoogle()
        {
            _driver.Quit();
            _driver = null;
        }


        public void AbrirPaginaGooglePesquisandoCerveja()
        {
            _driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl("http://www.google.com.br");

            //_driver.c
        }

    }
}
