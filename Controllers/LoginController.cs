using PKX.Data;
using PKX.Models;
using Microsoft.AspNetCore.Mvc;

namespace PKX.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDbContext db;
        public LoginController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index(string nomeUtilizador, string senha)
        {
            //caso não o login não tenha sido invocado de lado nenhum,
            //faz login e vai para a página pública  ou inicial (controller PUBLICA):
            if (HttpContext.Session.GetString("CONTROLADOR") == null)
                HttpContext.Session.SetString("CONTROLADOR", "Home");

            //verificar se esse nome existe na base de dados e
            //se a respetiva senha corresponde
            Utilizador u = new Utilizador   ();
            u = db.Utilizadores
                .FirstOrDefault(t => t.NomeUtilizador == nomeUtilizador && t.Senha == senha);

            if (u == null)
            {
                HttpContext.Session.SetString("UTILIZADOR", "");
                HttpContext.Session.SetString("CONTROLADOR", "Home");
                return View();
            }
            else
            {
                if (u.Estado != true)
                {   //está inativo? vai para a página pública
                    HttpContext.Session.SetString("UTILIZADOR", "");
                    HttpContext.Session.SetString("ESTADO", "");
                    return Redirect("~/Home/Index");
                }
                if (u.Estado == true && u.Administrador==true)
                {
                    HttpContext.Session.SetString("UTILIZADOR", u.NomeUtilizador.ToString());
                    HttpContext.Session.SetString("ADMINISTRADOR", "SIM");
                    HttpContext.Session.SetString("ESTADO", "ATIVO");
                    return Redirect("~/" + HttpContext.Session.GetString("CONTROLADOR") + "/Index");
                }
                if (u.Estado == true && u.Administrador == false)
                {
                    HttpContext.Session.SetString("UTILIZADOR", u.NomeUtilizador.ToString());
                    HttpContext.Session.SetString("ADMINISTRADOR", "");
                    HttpContext.Session.SetString("ESTADO", "ATIVO");
                    return Redirect("~/" + HttpContext.Session.GetString("CONTROLADOR") + "/Index");
                }
                {

                }
            }

            return View();

        }
    }
}
















//quer seja utilizador normal ou administrador, regressa à página que invocadora do login:
//   return Redirect("~/" + HttpContext.Session.GetString("CONTROLADOR") + "/Index");
