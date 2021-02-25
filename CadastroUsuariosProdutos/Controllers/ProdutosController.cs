using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadastroUsuariosProdutos.Models;

namespace CadastroUsuariosProdutos.Controllers
{
    public class ProdutosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        [Authorize(Roles = "Suporte, Cliente")]
        // GET: Produtos
        public ActionResult Index()
        {
            return View(db.Produtoes.ToList());
        }

        [Authorize(Roles = "Suporte, Cliente")]
        //GET: Produtos/Pesquisa
        public ActionResult Pesquisa()
        {
            using (var db = new ApplicationDbContext())
            {
                var _produtos = db.Produtoes.ToList();
                var data = new ProdutoViewModel()
                {
                    Produtos = _produtos
                };
                return View(data);
            }
        }

        [Authorize(Roles = "Suporte, Cliente")]
        //POST: Produtos/Pesquisa
        [HttpPost]
        public ActionResult Pesquisa(ProdutoViewModel produtoVm)
        {
           
                var produtoPesquisa = from pesquisaRec in db.Produtoes
                                      where ((produtoVm.Nome == null) || (pesquisaRec.Nome == produtoVm.Nome.Trim()))
                                           //&& ((produtoVm.Valor == null) || (pesquisaRec.Valor == produtoVm.Valor))
                                           && ((produtoVm.Tipo == null) || (pesquisaRec.Tipo == produtoVm.Tipo.Trim()))
                                      select new
                                      {
                                          Id = pesquisaRec.ProdutoId,
                                          Nome = pesquisaRec.Nome,
                                           Valor = pesquisaRec.Valor,
                                          Tipo = pesquisaRec.Tipo

                                      };
                List<Produto> listaProdutos = new List<Produto>();

                foreach (var reg in produtoPesquisa)
                {
                    Produto _produto = new Produto();
                    _produto.ProdutoId = reg.Id;
                    _produto.Nome = reg.Nome;
                    _produto.Valor = reg.Valor;
                    _produto.Tipo = reg.Tipo;
                    listaProdutos.Add(_produto);
                }

                produtoVm.Produtos = listaProdutos;

                return View(produtoVm);               
            
        }


        [Authorize(Roles = "Suporte, Cliente")]
        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [Authorize(Roles = "Suporte")]
        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Suporte")]
        // POST: Produtos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Valor,Tipo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtoes.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        [Authorize(Roles = "Suporte")]
        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [Authorize(Roles = "Suporte")]
        // POST: Produtos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Valor,Tipo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        [Authorize(Roles = "Suporte")]
        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        [Authorize(Roles = "Suporte")]
        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
