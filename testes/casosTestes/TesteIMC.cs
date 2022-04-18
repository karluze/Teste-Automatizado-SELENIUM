using System.IO;
using Microsoft.Extensions.Configuration;
using selenium;
using testes;
using testes.classes;
using Xunit;

namespace Testes.casosTestes
{
    public class TesteIMC : BaseTest
    {

        public TesteIMC() { }

        [Fact]
        public void TestarFireFox()
        {
            ExecutaTesteIMC(Browser.FireFox, 85, 1.74, 28.08, "Acima do Peso");

        }

        [Fact]
        public void TestarChrome()
        {
            ExecutaTesteIMC(Browser.Chrome, 50, 1.75, 16.33, "Muito abaixo do peso");
        }


        private void ExecutaTesteIMC(Browser browser, double peso, double altura,
           double valorEsperado, string mensagemEsperada)
        {
            IMC imc = new IMC(_configuration, browser);
            imc.CarregarPagina();
            imc.PreencherIMC(peso, altura);
            imc.CalcularIMC();
            var resultado = imc.ObterIMC();
            var mensagem = imc.ObterMensagem();
            imc.FecharPagina();

            Assert.NotEqual(0, resultado, 0);
            Assert.Equal(valorEsperado, resultado);
            Assert.NotEmpty(mensagem);
            Assert.Equal(mensagemEsperada, mensagem);

            bool contemOTexto = mensagem.Contains(mensagemEsperada);
            Assert.True(contemOTexto);

        }
    }
}
