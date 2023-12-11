using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string tokenSessao;

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.tokenSessao = "login";
        }

        public void addTokenLogin(Login login)
        {
            string loginTokenJson = JsonConvert.SerializeObject(login);
            this.httpContextAccessor.HttpContext?.Session.SetString(this.tokenSessao, loginTokenJson);
        }        

        public Login getTokenLogin()
        {
            string? loginTokenJson = this.httpContextAccessor.HttpContext?.Session.GetString(this.tokenSessao);
            return loginTokenJson != null ? JsonConvert.DeserializeObject<Login>(loginTokenJson) : null;
        }

        public void deleteTokenLogin()
        {
            this.httpContextAccessor.HttpContext?.Session.Remove(this.tokenSessao);
        }

        // Utilizado para adicionar ou remover ItensCarrinho dentro da sessão no controlador CarrinhoController.cs.
        /* 
        public void updateItensCarrinho(int valor)
        {
            var login = getTokenLogin();
            if (login != null)
            {
                login.ItensCarrinho = valor;
                addTokenLogin(login);
            }
        }            
        */

    }
}
