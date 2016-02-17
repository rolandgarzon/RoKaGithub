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
    public class rk_municipioController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_municipio
        public ActionResult Index()
        {
            var rk_municipio = db.rk_municipio.Include(r => r.rk_departamento);
            return View(rk_municipio.ToList());
        }

        // GET: rk_municipio/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_municipio rk_municipio = db.rk_municipio.Find(id);
            if (rk_municipio == null)
            {
                return HttpNotFound();
            }
            return View(rk_municipio);
        }

        // GET: rk_municipio/Create
        public ActionResult Create()
        {
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion");
            return View();
        }

        // POST: rk_municipio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmunicipio,descripcion,iddepartamento")] rk_municipio rk_municipio)
        {
            if (ModelState.IsValid)
            {
                db.rk_municipio.Add(rk_municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_municipio.iddepartamento);
            return View(rk_municipio);
        }

        // GET: rk_municipio/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_municipio rk_municipio = db.rk_municipio.Find(id);
            if (rk_municipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_municipio.iddepartamento);
            return View(rk_municipio);
        }

        // POST: rk_municipio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmunicipio,descripcion,iddepartamento")] rk_municipio rk_municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_municipio.iddepartamento);
            return View(rk_municipio);
        }

        // GET: rk_municipio/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_municipio rk_municipio = db.rk_municipio.Find(id);
            if (rk_municipio == null)
            {
                return HttpNotFound();
            }
            return View(rk_municipio);
        }

        // POST: rk_municipio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_municipio rk_municipio = db.rk_municipio.Find(id);
            db.rk_municipio.Remove(rk_municipio);
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
