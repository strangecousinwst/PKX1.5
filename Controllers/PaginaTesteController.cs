using Microsoft.AspNetCore.Mvc;

namespace PKX.Controllers
{
    public class PaginaTesteController : Controller
    {
        //[Authorize]

        public IActionResult Index()
        {
            ////guardar a página (controlador) para que o login
            ////caso seja invocado, retorne para aqui
            //HttpContext.Session.SetString("CONTROLADOR", "Privada");

            //if (HttpContext.Session.GetString("UTILIZADOR") != "" &&
            //    HttpContext.Session.GetString("UTILIZADOR") != null &&
            //    HttpContext.Session.GetString("ESTADO") == "ATIVO")
            //{
            //    return View();
            //}
            //else
            //    return Redirect("~/Login/Index");

            //2025-03-02
            //o teste sobre o estado do Login passa a estar diretamente na View:
            return View();
        }
    }
}
