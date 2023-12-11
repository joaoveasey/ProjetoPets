using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using WebApplication1.Models;
using WebApplication1.Repositories.ADO.SQLServer;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly Repositories.ADO.SQLServer.LoginDao repository;
        private readonly Services.ISessao sessao;

        public LoginController(IConfiguration configuration, Services.ISessao sessao)
        {            
            this.repository = new Repositories.ADO.SQLServer.LoginDao(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }

        public IActionResult Login()
        {          
            // Se o usuário não estiver logado retorna a View() senão retorna para a página de início.
            return this.sessao.getTokenLogin() == null ? View() : RedirectToAction("Index","Home");            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login login) 
        {
            #region "Login com controle de sessão."
            if (!string.IsNullOrEmpty(login.Usuario) && !string.IsNullOrEmpty(login.Senha))
            {
                if (this.repository.check(login))
                {
                    var loginResultado = repository.getTipo(login);
                    this.sessao.addTokenLogin(login);

                    if (loginResultado.TipoUsuario == "admin")
                        return RedirectToAction("Index", "Admin");
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!");               
            }
            return View();

            #endregion

            #region "Login sem controle de sessão."
            /*
            if (!string.IsNullOrEmpty(login.Usuario) && !string.IsNullOrEmpty(login.Senha))
            { 
                if (this.repository.check(login))                   
                    return RedirectToAction("Index", "Home");
                return RedirectToAction("Index", "Carros");
            }

            ViewBag.Error = "Usuário e/ou Senha Inválidos!";
            return View();
            */
            #endregion

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Login login)
        {
            try
            {
                repository.add(login);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        public IActionResult Logout() 
        {
            this.sessao.deleteTokenLogin();
            return RedirectToAction("Index", "Home"); 
        }

    }
}
