using contatosTestes.classesBase;
using selenium;
using Xunit;

namespace contatosTestes.casosTestes
{
    public class RegistrarLogarTeste : BaseTest
    {
        private string _email { get; set; }
        private string _senha { get; set; }


        public RegistrarLogarTeste()
        {
            _email = Faker.Internet.Email();
            _senha = "Mudar@123";
        }


        private void Executar(Browser browser, string email, string senha)
        {
            RegistrarLogin registrarLogin = new RegistrarLogin(_configuration, browser);
            registrarLogin.CarregarPagina();
            var emailLogado = registrarLogin.RegistrarUsuario(_email, _senha);
            registrarLogin.FecharPagina();

            Assert.NotEmpty(emailLogado);
            Assert.Equal(emailLogado, email);
        }

        private void ExecutarUsuarioJaRegistrado(Browser browser, string email, string senha)
        {
            RegistrarLogin registrarLogin = new RegistrarLogin(_configuration, browser);
            registrarLogin.CarregarPagina();
            var mensagem = registrarLogin.UsuarioJaRegistrado(_email, _senha);
            registrarLogin.FecharPagina();

            Assert.NotEmpty(mensagem);
            var existe = mensagem.Contains("already");
            Assert.True(existe);

            existe = mensagem.Contains(email);
            Assert.True(existe);

            existe = mensagem.Contains("email não existe");
            Assert.False(existe);
        }

        [Fact(DisplayName = "Chrome - Registrar e Logar Usuário")]
        public void TestarChome()
        {
            Executar(Browser.Chrome, _email, _senha);
            ExecutarUsuarioJaRegistrado(Browser.Chrome, _email, _senha);
        }

        //[Fact(Skip = "Teste FireFox")]
        [Fact]
        public void TestarFireFox()
        {
            Executar(Browser.FireFox, _email, _senha);
            ExecutarUsuarioJaRegistrado(Browser.Chrome, _email, _senha);
        }
    }
}
