using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDefinitivoComEntityFramework.Models;

namespace MVCDefinitivoComEntityFramework.Controllers
{
    public class tb_livroController : Controller
    {
        private MVCDefinitivoComEntityFrameworEntities3 db = new MVCDefinitivoComEntityFrameworEntities3();

        // GET: tb_livro
        public ActionResult Index()
        {
            var tb_livro = db.tb_livro.Include(t => t.tb_autor2);
            return View(tb_livro.ToList());
        }

        // GET: tb_livro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_livro tb_livro = db.tb_livro.Find(id);
            if (tb_livro == null)
            {
                return HttpNotFound();
            }
            return View(tb_livro);
        }

        // GET: tb_livro/Create
        public ActionResult Create()
        {
            ViewBag.AutorLivro = new SelectList(db.tb_autor2, "ID", "Nome");
            return View();
        }

        // POST: tb_livro/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Categoria,DataLancamento,AutorLivro")] tb_livro tb_livro)
        {
            if (ModelState.IsValid)
            {
                db.tb_livro.Add(tb_livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorLivro = new SelectList(db.tb_autor2, "ID", "Nome", tb_livro.AutorLivro);
            return View(tb_livro);
        }

        // GET: tb_livro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_livro tb_livro = db.tb_livro.Find(id);
            if (tb_livro == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorLivro = new SelectList(db.tb_autor2, "ID", "Nome", tb_livro.AutorLivro);
            return View(tb_livro);
        }

        // POST: tb_livro/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Categoria,DataLancamento,AutorLivro")] tb_livro tb_livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorLivro = new SelectList(db.tb_autor2, "ID", "Nome", tb_livro.AutorLivro);
            return View(tb_livro);
        }

        // GET: tb_livro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_livro tb_livro = db.tb_livro.Find(id);
            if (tb_livro == null)
            {
                return HttpNotFound();
            }
            return View(tb_livro);
        }

        // POST: tb_livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_livro tb_livro = db.tb_livro.Find(id);
            db.tb_livro.Remove(tb_livro);
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
