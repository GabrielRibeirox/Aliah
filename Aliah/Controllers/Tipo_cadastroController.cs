using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace VaiCaralhoMVC.Models
{
    public class Tipo_cadastroController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Tipo_cadastro
        public ActionResult Index()
        {
            return View(db.Tipo_cadastro.ToList());
        }

        // GET: Tipo_cadastro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_cadastro tipo_cadastro = db.Tipo_cadastro.Find(id);
            if (tipo_cadastro == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cadastro);
        }

        // GET: Tipo_cadastro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_cadastro/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] Tipo_cadastro tipo_cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_cadastro.Add(tipo_cadastro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_cadastro);
        }

        // GET: Tipo_cadastro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_cadastro tipo_cadastro = db.Tipo_cadastro.Find(id);
            if (tipo_cadastro == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cadastro);
        }

        // POST: Tipo_cadastro/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] Tipo_cadastro tipo_cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_cadastro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_cadastro);
        }

        // GET: Tipo_cadastro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_cadastro tipo_cadastro = db.Tipo_cadastro.Find(id);
            if (tipo_cadastro == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cadastro);
        }

        // POST: Tipo_cadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_cadastro tipo_cadastro = db.Tipo_cadastro.Find(id);
            db.Tipo_cadastro.Remove(tipo_cadastro);
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
