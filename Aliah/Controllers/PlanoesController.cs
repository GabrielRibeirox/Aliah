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
    public class PlanoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Planoes
        public ActionResult Index()
        {
            var plano = db.Plano.Include(p => p.Tipo_plano);
            return View(plano.ToList());
        }

        // GET: Planoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Plano.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        // GET: Planoes/Create
        public ActionResult Create()
        {
            ViewBag.Tipo_planoId = new SelectList(db.Tipo_plano, "Id", "Nome");
            return View();
        }

        // POST: Planoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data_inicio,Data_termino,Tipo_planoId")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                db.Plano.Add(plano);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo_planoId = new SelectList(db.Tipo_plano, "Id", "Nome", plano.Tipo_planoId);
            return View(plano);
        }

        // GET: Planoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Plano.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo_planoId = new SelectList(db.Tipo_plano, "Id", "Nome", plano.Tipo_planoId);
            return View(plano);
        }

        // POST: Planoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data_inicio,Data_termino,Tipo_planoId")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plano).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo_planoId = new SelectList(db.Tipo_plano, "Id", "Nome", plano.Tipo_planoId);
            return View(plano);
        }

        // GET: Planoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Plano.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        // POST: Planoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plano plano = db.Plano.Find(id);
            db.Plano.Remove(plano);
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
