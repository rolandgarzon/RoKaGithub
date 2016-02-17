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
    public class rk_departamentoController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_departamento
        public ActionResult Index()
        {
            var rk_departamento = db.rk_departamento.Include(r => r.rk_pais);
            return View(rk_departamento.ToList());
        }

        // GET: rk_departamento/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_departamento rk_departamento = db.rk_departamento.Find(id);
            if (rk_departamento == null)
            {
                return HttpNotFound();
            }
            return View(rk_departamento);
        }

        // GET: rk_departamento/Create
        public ActionResult Create()
        {
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion");
            return View();
        }

        // POST: rk_departamento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iddepartamento,descripcion,idpais")] rk_departamento rk_departamento)
        {
            if (ModelState.IsValid)
            {
                db.rk_departamento.Add(rk_departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_departamento.idpais);
            return View(rk_departamento);
        }

        // GET: rk_departamento/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_departamento rk_departamento = db.rk_departamento.Find(id);
            if (rk_departamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_departamento.idpais);
            return View(rk_departamento);
        }

        // POST: rk_departamento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iddepartamento,descripcion,idpais")] rk_departamento rk_departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_departamento.idpais);
            return View(rk_departamento);
        }

        // GET: rk_departamento/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_departamento rk_departamento = db.rk_departamento.Find(id);
            if (rk_departamento == null)
            {
                return HttpNotFound();
            }
            return View(rk_departamento);
        }

        // POST: rk_departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_departamento rk_departamento = db.rk_departamento.Find(id);
            db.rk_departamento.Remove(rk_departamento);
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
