using PKX.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace PKX.Controllers.Didaticos
{
    public class DropController : Controller
    {
        private readonly ApplicationDbContext db;
        public DropController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index(int Id)
        {
            ViewBag.DROPEQUIPAS =
                new SelectList(db.Utilizadores, "Id", "NomeUtilizador", Id);
            ViewBag.CHAVE = Id;//levar o Id para a View
            return View("~/Views/Didaticos/Drop/Index.cshtml");
        }
        public IActionResult Outra(int Id)
        {
            ViewBag.CHAVE = Id;//para fazer persistir
            return View("~/Views/Didaticos/Drop/Outra.cshtml");
        }
    }

}
