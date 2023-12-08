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
    public class tb_autor2Controller : Controller
    {
        private MVCDefinitivoComEntityFrameworEntities3 db = new MVCDefinitivoComEntityFrameworEntities3();

        // GET: tb_autor2
        public ActionResult Index()
        {
            return View(db.tb_autor2.ToList());
        }

        // GET: tb_autor2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_autor2 tb_autor2 = db.tb_autor2.Find(id);
            if (tb_autor2 == null)
            {
                return HttpNotFound();
            }
            return View(tb_autor2);
        }

        // GET: tb_autor2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_autor2/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,QtdLivrosEscritos")] tb_autor2 tb_autor2)
        {
            if (ModelState.IsValid)
            {
                db.tb_autor2.Add(tb_autor2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_autor2);
        }

        // GET: tb_autor2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_autor2 tb_autor2 = db.tb_autor2.Find(id);
            if (tb_autor2 == null)
            {
                return HttpNotFound();
            }
            return View(tb_autor2);
        }

        // POST: tb_autor2/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,QtdLivrosEscritos")] tb_autor2 tb_autor2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_autor2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_autor2);
        }

        // GET: tb_autor2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_autor2 tb_autor2 = db.tb_autor2.Find(id);
            if (tb_autor2 == null)
            {
                return HttpNotFound();
            }
            return View(tb_autor2);
        }

        // POST: tb_autor2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_autor2 tb_autor2 = db.tb_autor2.Find(id);
            db.tb_autor2.Remove(tb_autor2);
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
