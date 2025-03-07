using PKX.Data;
using PKX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PKX.Controllers
{
    public class GCliSenhas : Controller
    {
        private ApplicationDbContext db;
        public GCliSenhas(ApplicationDbContext context)
        {
            db = context;
        }
             
        public ActionResult Eliminar(int? IdItem)
        {
            ViewBag.R = db.Itens
                .Where(m => m.Id == IdItem)
                .Include(x => x.ClienteVirtual)
                .Include(y => y.TipoVirtual)   
                .FirstOrDefault();
            return View();


        }

        [HttpPost]
        public ActionResult Eliminar (int IdItem)
        {
            
            Item r = new Item();
            r = db.Itens.Where(m => m.Id == IdItem).FirstOrDefault();
            int cliente = r.ClienteId;
            db.Itens.Remove(r);
            db.SaveChanges();

            return RedirectToAction("Index", new { IdRegresso = cliente });
        }
        public IActionResult Index(int Id, int IdRegresso)//Id vem da drop
        {
            //se regressa ao index  vindo da editar/criar, o Id é o do regresso
            if (IdRegresso != 0) Id = IdRegresso;
          
            Id = (Id == 0? -1 : Id);//ainda nulo? fica com -1 para a drop não apresentar cliente
            //e forçar a escolhê-lo; assim o evento onchange da drop ocorrerá sempre, para atualizar a página
            
            
            if (Id==-1)
            ViewBag.LISTADECLIENTES = new SelectList(db.Clientes.OrderBy(m => m.NomeCliente), "Id", "NomeCliente","Escolher aqui");
              else
                ViewBag.LISTADECLIENTES = new SelectList(db.Clientes.OrderBy(m => m.NomeCliente), "Id", "NomeCliente", Id);
            
            //itens do cliente que foi escohlido:
            ViewBag.LISTADEITENS = db.Itens.Where(m => m.ClienteId == Id)
                .Include(x=>x.TipoVirtual).ToList();
            ViewBag.IDCLIENTESELECIONADO = Id;
            return View();
        }

        public IActionResult Criar(int? Id)
        {
            Id = Id > 0 ? Id : -1;
            if (Id !=-1)
            {
                //ViewBag.IDCLIENTE = Id;
                ViewBag.NOMECLIENTE = db.Clientes.Where(m => m.Id == Id).FirstOrDefault().NomeCliente;
                ViewBag.LISTADETIPOS = new SelectList(db.Tipos.OrderBy(m => m.Designacao), "Id", "Designacao");
                ViewBag.IDCLIENTESELECIONADO = Id;
            return View();
            }
            else
            {
                ViewBag.CLIENTE = db.Clientes.Where(m => m.Id == Id).FirstOrDefault().NomeCliente;
                ViewBag.IDCLIENTESELECIONADO = Id;
                return View();
                //return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Criar ( int ClienteId, int dropTipo,
                                    string Item1, string Item2, string Texto)
        {   //os dados são recebidos da view via argumentos
            //criar um objeto da class Item:
            Models.Item r = new Models.Item();
            //preencher o objeto com os dados recebidos:
            //r.Id; -> não; async PK é Identity
            r.ClienteId = ClienteId;
            r.TipoId= dropTipo;
            r.Item1 = Item1;
            r.Item2 = Item2;
            r.Texto = Texto;
            //atualizar a base de dados:
            db.Add(r);
            db.SaveChanges();
            //retornar ao método Index ( em vez de Return View() )
            return RedirectToAction("Index", new {IdRegresso = ClienteId});
        }

        public IActionResult Editar (int IdItem)
        {
            //extrair registo da base de dados e enviar para a view:
            ViewBag.R = db.Itens.Where(m => m.Id == IdItem)
                .Include(x=>x.TipoVirtual)
                .Include(y=>y.ClienteVirtual)
                .FirstOrDefault();

            return View();
        }
        [HttpPost]
        public IActionResult Editar (int Id, int ClienteId, int TipoId,
                                    string Item1, string Item2, string Texto)
        {   //os dados são recebidos da view via argumentos
            //criar um objeto da class Item:
            Models.Item r = new Models.Item();
            //preencher o objeto com os dados recebidos:
            r.Id = Id;
            r.ClienteId = ClienteId;
            r.TipoId= TipoId;
            r.Item1 = Item1;
            r.Item2 = Item2;
            r.Texto = Texto;
            //atualizar a base de dados:
            db.Update(r);
            db.SaveChanges();
            //retornar ao método Index ( em vez de Return View() )
            return RedirectToAction("Index", new {IdRegresso = ClienteId});
        }
        
        
 //GARAGEM       ################################################################################################## GARAGEM 
        //public IActionResult Editar(int IdItem)
        //{
        //    //extrair registo da base de dados e enviar para a view:
        //    ViewBag.R = db.TItems.Where(m => m.Id == IdItem).FirstOrDefault();
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Editar(int Id, int ClienteId, int TipoId,
        //                            string Item1, string Item2, string Texto)
        //{   //os dados são recebidos da view via argumentos
        //    //criar um objeto da class Item:
        //    Models.Item r = new Models.Item();
        //    //preencher o objeto com os dados recebidos:
        //    r.Id = Id;
        //    r.ClienteId = ClienteId;
        //    r.TipoId = TipoId;
        //    r.Item1 = Item1;
        //    r.Item2 = Item2;
        //    r.Texto = Texto;
        //    //atualizar a base de dados:
        //    db.Update(r);
        //    db.SaveChanges();
        //    //retornar ao método Index ( em vez de Return View() )
        //    return RedirectToAction("Index", new { Id = ClienteId });
        //}
        //««««««««««««««««««««««««««««««««««««««««« »»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
        //VERSÃO ANTERIOR:
        //public IActionResult Editar (int IdItem)
        //{
        //    //FAZER ISTO PASSO A PASSO:
        //    //buscar à base de dados:
        //    var colecao = db.TItems.Where(m => m.Id == IdItem);
        //    //na verdade, a coleção é apenas um registo, certo? (PK...)
        //    //ou seja, não é um conjunto de Items, é apenas UM Item
        //    //então... converter a coleção num registo simples:
        //    var registo = colecao.FirstOrDefault();
        //    //registo levará para a view o registo selecionado
        //    ViewBag.R = registo;

        //    //FAZER O MESMO, NUMA SÓ LINHA:
        //    //(a linha seguinte faz o mesmo que as anteriores)
        //    ViewBag.R = db.TItems.Where(m => m.Id == IdItem).FirstOrDefault();
        //    return View();
        //}
    }
}
