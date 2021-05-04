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
    public class MoedasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Moedas
        public ActionResult Index()
        {
            PlanoMoeda pm = new PlanoMoeda();
            pm.Planos = db.Tipo_plano.ToList();
            pm.Moedas = db.Moeda.ToList();
            return View(pm);
        }

        // GET: Moedas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moeda moeda = db.Moeda.Find(id);
            if (moeda == null)
            {
                return HttpNotFound();
            }
            return View(moeda);
        }

        // GET: Moedas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moedas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Quantidade,Valor,Validade,Status")] Moeda moeda)
        {
            if (ModelState.IsValid)
            {
                db.Moeda.Add(moeda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moeda);
        }

        // GET: Moedas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moeda moeda = db.Moeda.Find(id);
            if (moeda == null)
            {
                return HttpNotFound();
            }
            return View(moeda);
        }

        // POST: Moedas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Quantidade,Valor,Validade,Status")] Moeda moeda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moeda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moeda);
        }

        // GET: Moedas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moeda moeda = db.Moeda.Find(id);
            if (moeda == null)
            {
                return HttpNotFound();
            }
            return View(moeda);
        }

        // POST: Moedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moeda moeda = db.Moeda.Find(id);
            db.Moeda.Remove(moeda);
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

