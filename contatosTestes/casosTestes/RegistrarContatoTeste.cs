using contatosTestes.classes;
using contatosTestes.classesBase;
using selenium;
using Xunit;

namespace contatosTestes.casosTestes
{
    public class RegistrarContatoTeste : BaseTest
    {
        private void CadastrarContato(Browser browser)
        {
            Login(browser, emailPadrão, senhaEmailPadrão);
            RegistrarContato registrar = new RegistrarContato();
            var contatoDto = registrar.CadastrarContato();
            PesquisarContato pesquisar = new PesquisarContato();
            var lista = pesquisar.PesquisarContatoNome(contatoDto);
            var nomeCadastrado = contatoDto.Nome;

            Assert.NotNull(contatoDto);
            Assert.Equal(lista[0], contatoDto.Nome);
            Assert.Equal(lista[1], contatoDto.Email);

            var contatoDtoEditado = registrar.EditarContato();
            lista = pesquisar.PesquisarContatoNome(contatoDtoEditado);

            Assert.NotNull(contatoDtoEditado);
            Assert.Equal(lista[0], contatoDtoEditado.Nome);
            Assert.Equal(lista[1], contatoDtoEditado.Email);
            Assert.NotEqual(nomeCadastrado, contatoDtoEditado.Nome);

            registrar.ExcluirContatoBotaoCancelar();
            lista = pesquisar.PesquisarContatoNome(contatoDtoEditado);
            Assert.Equal(lista[0], contatoDtoEditado.Nome);
            Assert.Equal(lista[1], contatoDtoEditado.Email);
            Assert.NotEqual(nomeCadastrado, contatoDtoEditado.Nome);

            registrar.ExcluirContato();
            var mensagem = pesquisar.PesquisarContatoNomePosDelete(contatoDtoEditado);
            Driver.FecharPaginaSelenium();

            Assert.NotEmpty(mensagem);
            var existe = mensagem.Contains("Não existem contatos cadastrados...");
            Assert.True(existe);

        }

        [Fact(DisplayName = "Chrome - Registrar Contato")]
        [Trait("Contatos", "Crud")]
        public void TestarChrome()
        {
            CadastrarContato(Browser.Chrome);
        }

        [Fact(Skip = "Teste FireFox")]
        //[Fact]
        public void TestarFireFox()
        {
            CadastrarContato(Browser.FireFox);
        }

    }
}
