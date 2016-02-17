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
    public class rk_formularioController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_formulario
        public ActionResult Index()
        {
            return View(db.rk_formulario.ToList());
        }

        // GET: rk_formulario/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_formulario rk_formulario = db.rk_formulario.Find(id);
            if (rk_formulario == null)
            {
                return HttpNotFound();
            }
            return View(rk_formulario);
        }

        // GET: rk_formulario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rk_formulario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idformulario,descripcion")] rk_formulario rk_formulario)
        {
            if (ModelState.IsValid)
            {
                db.rk_formulario.Add(rk_formulario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rk_formulario);
        }

        // GET: rk_formulario/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_formulario rk_formulario = db.rk_formulario.Find(id);
            if (rk_formulario == null)
            {
                return HttpNotFound();
            }
            return View(rk_formulario);
        }

        // POST: rk_formulario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idformulario,descripcion")] rk_formulario rk_formulario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_formulario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rk_formulario);
        }

        // GET: rk_formulario/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_formulario rk_formulario = db.rk_formulario.Find(id);
            if (rk_formulario == null)
            {
                return HttpNotFound();
            }
            return View(rk_formulario);
        }

        // POST: rk_formulario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_formulario rk_formulario = db.rk_formulario.Find(id);
            db.rk_formulario.Remove(rk_formulario);
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
