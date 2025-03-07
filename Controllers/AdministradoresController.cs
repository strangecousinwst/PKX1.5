using Microsoft.AspNetCore.Mvc;

namespace PKX.Controllers
{
    public class AdministradoresController : Controller
    {
        public IActionResult Index()
        {
            //guardar a página (controlador) para que o logi
            //caso seja invocado, retorne para aqui
            HttpContext.Session.SetString("CONTROLADOR", "Administradores");

            if (HttpContext.Session.GetString("UTILIZADOR") == "" ||
                HttpContext.Session.GetString("UTILIZADOR") == null)          
                {
                    return Redirect("~/Login/Index");
                }
            else if (HttpContext.Session.GetString("ADMINISTRADOR") == "SIM"
                        && HttpContext.Session.GetString("ESTADO") == "ATIVO")
                return  View(); 
            else
                return Redirect("~/Login/Index");
        }
    }
}
