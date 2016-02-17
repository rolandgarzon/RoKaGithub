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
    public class rk_observacioneslecturaController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_observacioneslectura
        public ActionResult Index()
        {
            var rk_observacioneslectura = db.rk_observacioneslectura.Include(r => r.rk_servicio).Include(r => r.rk_tipocobroobervacion).Include(r => r.rk_tipoobervacionlectura);
            return View(rk_observacioneslectura.ToList());
        }

        // GET: rk_observacioneslectura/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_observacioneslectura rk_observacioneslectura = db.rk_observacioneslectura.Find(id);
            if (rk_observacioneslectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_observacioneslectura);
        }

        // GET: rk_observacioneslectura/Create
        public ActionResult Create()
        {
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion");
            ViewBag.idtipocobro = new SelectList(db.rk_tipocobroobervacion, "idtipocobro", "descripcion");
            ViewBag.idtipoobservacionlectura = new SelectList(db.rk_tipoobervacionlectura, "idtipoobservacionlectura", "descripcion");
            return View();
        }

        // POST: rk_observacioneslectura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idobservacionlectura,descripcion,idtipoobservacionlectura,idtipocobro,idservicio")] rk_observacioneslectura rk_observacioneslectura)
        {
            if (ModelState.IsValid)
            {
                db.rk_observacioneslectura.Add(rk_observacioneslectura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_observacioneslectura.idservicio);
            ViewBag.idtipocobro = new SelectList(db.rk_tipocobroobervacion, "idtipocobro", "descripcion", rk_observacioneslectura.idtipocobro);
            ViewBag.idtipoobservacionlectura = new SelectList(db.rk_tipoobervacionlectura, "idtipoobservacionlectura", "descripcion", rk_observacioneslectura.idtipoobservacionlectura);
            return View(rk_observacioneslectura);
        }

        // GET: rk_observacioneslectura/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_observacioneslectura rk_observacioneslectura = db.rk_observacioneslectura.Find(id);
            if (rk_observacioneslectura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_observacioneslectura.idservicio);
            ViewBag.idtipocobro = new SelectList(db.rk_tipocobroobervacion, "idtipocobro", "descripcion", rk_observacioneslectura.idtipocobro);
            ViewBag.idtipoobservacionlectura = new SelectList(db.rk_tipoobervacionlectura, "idtipoobservacionlectura", "descripcion", rk_observacioneslectura.idtipoobservacionlectura);
            return View(rk_observacioneslectura);
        }

        // POST: rk_observacioneslectura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idobservacionlectura,descripcion,idtipoobservacionlectura,idtipocobro,idservicio")] rk_observacioneslectura rk_observacioneslectura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_observacioneslectura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_observacioneslectura.idservicio);
            ViewBag.idtipocobro = new SelectList(db.rk_tipocobroobervacion, "idtipocobro", "descripcion", rk_observacioneslectura.idtipocobro);
            ViewBag.idtipoobservacionlectura = new SelectList(db.rk_tipoobervacionlectura, "idtipoobservacionlectura", "descripcion", rk_observacioneslectura.idtipoobservacionlectura);
            return View(rk_observacioneslectura);
        }

        // GET: rk_observacioneslectura/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_observacioneslectura rk_observacioneslectura = db.rk_observacioneslectura.Find(id);
            if (rk_observacioneslectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_observacioneslectura);
        }

        // POST: rk_observacioneslectura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_observacioneslectura rk_observacioneslectura = db.rk_observacioneslectura.Find(id);
            db.rk_observacioneslectura.Remove(rk_observacioneslectura);
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
