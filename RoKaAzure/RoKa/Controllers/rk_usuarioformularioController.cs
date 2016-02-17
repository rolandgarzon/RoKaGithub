using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoKa.Models;

namespace RoKa.Controllers
{
    public class rk_usuarioformularioController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_usuarioformulario
        public ActionResult Index()
        {
            var rk_usuarioformulario = db.rk_usuarioformulario.Include(r => r.rk_formulario).Include(r => r.rk_usuario);
            return View(rk_usuarioformulario.ToList());
        }

        // GET: rk_usuarioformulario/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_usuarioformulario rk_usuarioformulario = db.rk_usuarioformulario.Find(id);
            if (rk_usuarioformulario == null)
            {
                return HttpNotFound();
            }
            return View(rk_usuarioformulario);
        }

        // GET: rk_usuarioformulario/Create
        public ActionResult Create()
        {
            ViewBag.idformulario = new SelectList(db.rk_formulario, "idformulario", "descripcion");
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto");
            return View();
        }

        // POST: rk_usuarioformulario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idusuario,idformulario")] rk_usuarioformulario rk_usuarioformulario)
        {
            if (ModelState.IsValid)
            {
                db.rk_usuarioformulario.Add(rk_usuarioformulario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idformulario = new SelectList(db.rk_formulario, "idformulario", "descripcion", rk_usuarioformulario.idformulario);
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto", rk_usuarioformulario.idusuario);
            return View(rk_usuarioformulario);
        }

        // GET: rk_usuarioformulario/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_usuarioformulario rk_usuarioformulario = db.rk_usuarioformulario.Find(id);
            if (rk_usuarioformulario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idformulario = new SelectList(db.rk_formulario, "idformulario", "descripcion", rk_usuarioformulario.idformulario);
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto", rk_usuarioformulario.idusuario);
            return View(rk_usuarioformulario);
        }

        // POST: rk_usuarioformulario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idusuario,idformulario")] rk_usuarioformulario rk_usuarioformulario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_usuarioformulario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idformulario = new SelectList(db.rk_formulario, "idformulario", "descripcion", rk_usuarioformulario.idformulario);
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto", rk_usuarioformulario.idusuario);
            return View(rk_usuarioformulario);
        }

        // GET: rk_usuarioformulario/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_usuarioformulario rk_usuarioformulario = db.rk_usuarioformulario.Find(id);
            if (rk_usuarioformulario == null)
            {
                return HttpNotFound();
            }
            return View(rk_usuarioformulario);
        }

        // POST: rk_usuarioformulario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_usuarioformulario rk_usuarioformulario = db.rk_usuarioformulario.Find(id);
            db.rk_usuarioformulario.Remove(rk_usuarioformulario);
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
