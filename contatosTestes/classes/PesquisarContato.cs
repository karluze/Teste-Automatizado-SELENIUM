using System.Collections.Generic;
using contatosTestes.classesBase;
using OpenQA.Selenium;
using selenium;

namespace contatosTestes.classes
{
    public class PesquisarContato
    {
        private IWebDriver _driver = null;

        public PesquisarContato()
        {
            _driver = Driver.GetInstance();
        }

        public List<string> PesquisarContatoNome(ContatoDto contatoDto)
        {
            _driver.Esperar(By.Id("nomeFiltro"));
            _driver.AtribuirValor(By.Id("nomeFiltro"), contatoDto.Nome);
            _driver.Clique(By.Name("btnFiltrar"));
            return _driver.ObterValorTabela(By.Id("tabelaId"));
        }

        public string PesquisarContatoNomePosDelete(ContatoDto contatoDto)
        {
            _driver.Esperar(By.Id("nomeFiltro"));
            _driver.AtribuirValor(By.Id("nomeFiltro"), contatoDto.Nome);
            _driver.Clique(By.Name("btnFiltrar"));
            _driver.Esperar(By.ClassName("alert"));
            return _driver.ObterValor(By.ClassName("alert"));
        }
    }
}

