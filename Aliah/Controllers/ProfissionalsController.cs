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
    [Authorize(Roles = "Profissioanl")]
    public class ProfissionalsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Profissionals
        public ActionResult Index()
        {
			List<Profissional> cp = new List<Profissional>();
			
			cp = db.Profissional.ToList();
			
			//cp.Enderecos = db.Endereco.ToList();
			return View(cp);
			//var profissional = db.Profissional.Include(p => p.Escolaridade).Include(p => p.Plano).Include(p => p.Usuario);
			//return View(profissional.ToList());
		}

        // GET: Profissionals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissional profissional = db.Profissional.Find(id);
            if (profissional == null)
            {
                return HttpNotFound();
            }
            return View(profissional);
        }

        // GET: Profissionals/Create
        public ActionResult Create()
        {
            ViewBag.EscolaridadeId = new SelectList(db.Escolaridade, "Id", "Curso");
            ViewBag.PlanoId = new SelectList(db.Plano, "Id", "Data_inicio");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome");
            return View();
        }

        // POST: Profissionals/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Profissao,Disponibilidade,Experiencia,Foto_perfil,UsuarioId,EscolaridadeId,PlanoId,Comprovante_residencia,Antecedentes_criminais")] Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                db.Profissional.Add(profissional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EscolaridadeId = new SelectList(db.Escolaridade, "Id", "Curso", profissional.EscolaridadeId);
            ViewBag.PlanoId = new SelectList(db.Plano, "Id", "Data_inicio", profissional.PlanoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", profissional.UsuarioId);
            return View(profissional);
        }

        // GET: Profissionals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissional profissional = db.Profissional.Find(id);
            if (profissional == null)
            {
                return HttpNotFound();
            }
            ViewBag.EscolaridadeId = new SelectList(db.Escolaridade, "Id", "Curso", profissional.EscolaridadeId);
            ViewBag.PlanoId = new SelectList(db.Plano, "Id", "Data_inicio", profissional.PlanoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", profissional.UsuarioId);
            return View(profissional);
        }

        // POST: Profissionals/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Profissao,Disponibilidade,Experiencia,Foto_perfil,UsuarioId,EscolaridadeId,PlanoId,Comprovante_residencia,Antecedentes_criminais")] Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profissional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EscolaridadeId = new SelectList(db.Escolaridade, "Id", "Curso", profissional.EscolaridadeId);
            ViewBag.PlanoId = new SelectList(db.Plano, "Id", "Data_inicio", profissional.PlanoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", profissional.UsuarioId);
            return View(profissional);
        }

        // GET: Profissionals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissional profissional = db.Profissional.Find(id);
            if (profissional == null)
            {
                return HttpNotFound();
            }
            return View(profissional);
        }

        // POST: Profissionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profissional profissional = db.Profissional.Find(id);
            db.Profissional.Remove(profissional);
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
