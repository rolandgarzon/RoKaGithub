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
    public class rk_estadolecturaController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_estadolectura
        public ActionResult Index()
        {
            return View(db.rk_estadolectura.ToList());
        }

        // GET: rk_estadolectura/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_estadolectura rk_estadolectura = db.rk_estadolectura.Find(id);
            if (rk_estadolectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_estadolectura);
        }

        // GET: rk_estadolectura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rk_estadolectura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idestadolectura,descripcion")] rk_estadolectura rk_estadolectura)
        {
            if (ModelState.IsValid)
            {
                db.rk_estadolectura.Add(rk_estadolectura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rk_estadolectura);
        }

        // GET: rk_estadolectura/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_estadolectura rk_estadolectura = db.rk_estadolectura.Find(id);
            if (rk_estadolectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_estadolectura);
        }

        // POST: rk_estadolectura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idestadolectura,descripcion")] rk_estadolectura rk_estadolectura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_estadolectura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rk_estadolectura);
        }

        // GET: rk_estadolectura/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_estadolectura rk_estadolectura = db.rk_estadolectura.Find(id);
            if (rk_estadolectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_estadolectura);
        }

        // POST: rk_estadolectura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_estadolectura rk_estadolectura = db.rk_estadolectura.Find(id);
            db.rk_estadolectura.Remove(rk_estadolectura);
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
