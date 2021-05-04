using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VaiCaralhoMVC.Models;

namespace VaiCaralhoMVC.Controllers
{
    public class Formulario_contatoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Formulario_contato
        public ActionResult Index()
        {
            return View(db.Formulario_contato.ToList());
        }

        // GET: Formulario_contato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulario_contato formulario_contato = db.Formulario_contato.Find(id);
            if (formulario_contato == null)
            {
                return HttpNotFound();
            }
            return View(formulario_contato);
        }

        // GET: Formulario_contato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formulario_contato/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,Telefone,Assunto,Descricao")] Formulario_contato formulario_contato)
        {
            if (ModelState.IsValid)
            {
                db.Formulario_contato.Add(formulario_contato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formulario_contato);
        }

        // GET: Formulario_contato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulario_contato formulario_contato = db.Formulario_contato.Find(id);
            if (formulario_contato == null)
            {
                return HttpNotFound();
            }
            return View(formulario_contato);
        }

        // POST: Formulario_contato/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Telefone,Assunto,Descricao")] Formulario_contato formulario_contato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formulario_contato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formulario_contato);
        }

        // GET: Formulario_contato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulario_contato formulario_contato = db.Formulario_contato.Find(id);
            if (formulario_contato == null)
            {
                return HttpNotFound();
            }
            return View(formulario_contato);
        }

        // POST: Formulario_contato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formulario_contato formulario_contato = db.Formulario_contato.Find(id);
            db.Formulario_contato.Remove(formulario_contato);
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
