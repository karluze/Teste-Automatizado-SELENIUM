using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using selenium;

namespace testes.classes
{
    public class IMC : BaseClass
    {

        public IMC(IConfiguration configuration, Browser browser)
        : base(configuration, browser)
        {
        }


        public void CarregarPagina()
        {
            _driver.AbrirPaginaNavegador(TimeSpan.FromSeconds(5), _configuration.GetSection("Selenium:UrlAplicacao").Value);
        }

        public void FecharPagina()
        {
            _driver.Quit();
            _driver = null;
        }

        public void PreencherIMC(double peso, double altura)
        {
            _driver.AtribuirValor(By.Id("id_Peso"), peso.ToString());
            _driver.AtribuirValor(By.Name("Altura"), altura.ToString());
        }

        public void CalcularIMC()
        {
            _driver.Enviar(By.Id("id_btnCalcular"));
            _driver.Esperar(By.Id("ResultImc"), TimeSpan.FromSeconds(10));
        }

        public double ObterIMC()
        {
            return Convert.ToDouble(_driver.ObterValor(By.Id("ResultImc")));
        }

        public string ObterMensagem()
        {
            return _driver.ObterValor(By.ClassName("alert"));
        }

    }
}
