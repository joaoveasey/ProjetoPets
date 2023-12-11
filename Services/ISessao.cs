using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ISessao
    {
        void addTokenLogin(Login login);

        Login getTokenLogin();

        // Adicionar na Classe de Sessão (Sessao.cs) todos os métodos que estarão protegidos pela sessão.
        // void updateItensCarrinho(int valor);

        void deleteTokenLogin();
    }
}
