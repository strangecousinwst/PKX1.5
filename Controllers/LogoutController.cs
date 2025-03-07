using Microsoft.AspNetCore.Mvc;

namespace PKX.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            //limpar a variável de sessão UTILIZADOR:
            HttpContext.Session.SetString("UTILIZADOR", "");

            //redirecionar para a primeira págibna da aplicação:
            return Redirect("Home");
            
        }
    }
}
