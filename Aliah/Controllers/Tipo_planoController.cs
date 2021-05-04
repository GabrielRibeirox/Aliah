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
    public class Tipo_planoController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            return View(db.Tipo_plano.ToList());
        }
        // GET: Tipo_plano
        public ActionResult Tipo_plano()
        {
			List<Tipo_plano> cp = new List<Tipo_plano>();

			PlanoMoeda pm = new PlanoMoeda();
            pm.Planos = db.Tipo_plano.ToList();
            pm.Moedas = db.Moeda.ToList();
            return View(pm);
        }

        // GET: Tipo_plano/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_plano tipo_plano = db.Tipo_plano.Find(id);
            if (tipo_plano == null)
            {
                return HttpNotFound();
            }
            return View(tipo_plano);
        }

        // GET: Tipo_plano/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_plano/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Valor")] Tipo_plano tipo_plano)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_plano.Add(tipo_plano);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_plano);
        }

        // GET: Tipo_plano/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_plano tipo_plano = db.Tipo_plano.Find(id);
            if (tipo_plano == null)
            {
                return HttpNotFound();
            }
            return View(tipo_plano);
        }

        // POST: Tipo_plano/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Valor")] Tipo_plano tipo_plano)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_plano).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_plano);
        }

        // GET: Tipo_plano/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_plano tipo_plano = db.Tipo_plano.Find(id);
            if (tipo_plano == null)
            {
                return HttpNotFound();
            }
            return View(tipo_plano);
        }

        // POST: Tipo_plano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_plano tipo_plano = db.Tipo_plano.Find(id);
            db.Tipo_plano.Remove(tipo_plano);
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
