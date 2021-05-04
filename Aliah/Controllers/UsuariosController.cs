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
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Usuarios
         [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
			UsuarioEndereco us = new UsuarioEndereco();
			us.Usuarios = db.Usuario.ToList();
			us.Enderecos = db.Endereco.ToList();
			return View(us);
            //var usuario = db.Usuario.Include(u => u.Tipo_cadastro);
            //return View(usuario.ToList());
        }

		

		public ActionResult MeuPerfil(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Usuario usuario = db.Usuario.Find(id);

			if (usuario == null)
			{
				return HttpNotFound();
			}
			return View(usuario);
		}

		// GET: Usuarios/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario usuario = db.Usuario.Find(id);

			if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.Tipo_cadastroId = new SelectList(db.Tipo_cadastro, "Id", "Descricao");
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cpf,Data_nascimento,Sexo,Email,Senha,Celular,Telefone,Status,Hash,Tipo_cadastroId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo_cadastroId = new SelectList(db.Tipo_cadastro, "Id", "Descricao", usuario.Tipo_cadastroId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo_cadastroId = new SelectList(db.Tipo_cadastro, "Id", "Descricao", usuario.Tipo_cadastroId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cpf,Data_nascimento,Sexo,Email,Senha,Celular,Telefone,Status,Hash,Tipo_cadastroId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                TempData["MSG"] = "success|Cadastro efetuado com sucesso!";
                return RedirectToAction("Index");
            }
            ViewBag.Tipo_cadastroId = new SelectList(db.Tipo_cadastro, "Id", "Descricao", usuario.Tipo_cadastroId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

			return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
