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
    public class rk_tipocobroobervacionController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_tipocobroobervacion
        public ActionResult Index()
        {
            var rk_tipocobroobervacion = db.rk_tipocobroobervacion.Include(r => r.rk_servicio);
            return View(rk_tipocobroobervacion.ToList());
        }

        // GET: rk_tipocobroobervacion/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_tipocobroobervacion rk_tipocobroobervacion = db.rk_tipocobroobervacion.Find(id);
            if (rk_tipocobroobervacion == null)
            {
                return HttpNotFound();
            }
            return View(rk_tipocobroobervacion);
        }

        // GET: rk_tipocobroobervacion/Create
        public ActionResult Create()
        {
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion");
            return View();
        }

        // POST: rk_tipocobroobervacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtipocobro,descripcion,idservicio")] rk_tipocobroobervacion rk_tipocobroobervacion)
        {
            if (ModelState.IsValid)
            {
                db.rk_tipocobroobervacion.Add(rk_tipocobroobervacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_tipocobroobervacion.idservicio);
            return View(rk_tipocobroobervacion);
        }

        // GET: rk_tipocobroobervacion/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_tipocobroobervacion rk_tipocobroobervacion = db.rk_tipocobroobervacion.Find(id);
            if (rk_tipocobroobervacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_tipocobroobervacion.idservicio);
            return View(rk_tipocobroobervacion);
        }

        // POST: rk_tipocobroobervacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtipocobro,descripcion,idservicio")] rk_tipocobroobervacion rk_tipocobroobervacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_tipocobroobervacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_tipocobroobervacion.idservicio);
            return View(rk_tipocobroobervacion);
        }

        // GET: rk_tipocobroobervacion/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_tipocobroobervacion rk_tipocobroobervacion = db.rk_tipocobroobervacion.Find(id);
            if (rk_tipocobroobervacion == null)
            {
                return HttpNotFound();
            }
            return View(rk_tipocobroobervacion);
        }

        // POST: rk_tipocobroobervacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_tipocobroobervacion rk_tipocobroobervacion = db.rk_tipocobroobervacion.Find(id);
            db.rk_tipocobroobervacion.Remove(rk_tipocobroobervacion);
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
