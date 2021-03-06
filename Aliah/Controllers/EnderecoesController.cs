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
    public class EnderecoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Enderecoes
        public ActionResult Index()
        {
            var endereco = db.Endereco.Include(e => e.Tipo_endereco).Include(e => e.Usuario);
            return View(endereco.ToList());
        }

        // GET: Enderecoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Enderecoes/Create
        public ActionResult Create()
        {
            ViewBag.Tipo_enderecoId = new SelectList(db.Tipo_endereco, "Id", "Descricao");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome");
            return View();
        }

        // POST: Enderecoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rua,Numero,Bairro,Cidade,Cep,Estado,UsuarioId,Tipo_enderecoId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Endereco.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo_enderecoId = new SelectList(db.Tipo_endereco, "Id", "Descricao", endereco.Tipo_enderecoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", endereco.UsuarioId);
            return View(endereco);
        }

        // GET: Enderecoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo_enderecoId = new SelectList(db.Tipo_endereco, "Id", "Descricao", endereco.Tipo_enderecoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", endereco.UsuarioId);
            return View(endereco);
        }

        // POST: Enderecoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rua,Numero,Bairro,Cidade,Cep,Estado,UsuarioId,Tipo_enderecoId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo_enderecoId = new SelectList(db.Tipo_endereco, "Id", "Descricao", endereco.Tipo_enderecoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", endereco.UsuarioId);
            return View(endereco);
        }

        // GET: Enderecoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = db.Endereco.Find(id);
            db.Endereco.Remove(endereco);
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
