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
    public class rk_tipoobervacionlecturaController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_tipoobervacionlectura
        public ActionResult Index()
        {
            return View(db.rk_tipoobervacionlectura.ToList());
        }

        // GET: rk_tipoobervacionlectura/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_tipoobervacionlectura rk_tipoobervacionlectura = db.rk_tipoobervacionlectura.Find(id);
            if (rk_tipoobervacionlectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_tipoobervacionlectura);
        }

        // GET: rk_tipoobervacionlectura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rk_tipoobervacionlectura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtipoobservacionlectura,descripcion")] rk_tipoobervacionlectura rk_tipoobervacionlectura)
        {
            if (ModelState.IsValid)
            {
                db.rk_tipoobervacionlectura.Add(rk_tipoobervacionlectura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rk_tipoobervacionlectura);
        }

        // GET: rk_tipoobervacionlectura/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_tipoobervacionlectura rk_tipoobervacionlectura = db.rk_tipoobervacionlectura.Find(id);
            if (rk_tipoobervacionlectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_tipoobervacionlectura);
        }

        // POST: rk_tipoobervacionlectura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtipoobservacionlectura,descripcion")] rk_tipoobervacionlectura rk_tipoobervacionlectura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_tipoobervacionlectura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rk_tipoobervacionlectura);
        }

        // GET: rk_tipoobervacionlectura/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_tipoobervacionlectura rk_tipoobervacionlectura = db.rk_tipoobervacionlectura.Find(id);
            if (rk_tipoobervacionlectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_tipoobervacionlectura);
        }

        // POST: rk_tipoobervacionlectura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_tipoobervacionlectura rk_tipoobervacionlectura = db.rk_tipoobervacionlectura.Find(id);
            db.rk_tipoobervacionlectura.Remove(rk_tipoobervacionlectura);
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
