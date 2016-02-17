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
    public class rk_servicioController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_servicio
        public ActionResult Index()
        {
            return View(db.rk_servicio.ToList());
        }

        // GET: rk_servicio/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_servicio rk_servicio = db.rk_servicio.Find(id);
            if (rk_servicio == null)
            {
                return HttpNotFound();
            }
            return View(rk_servicio);
        }

        // GET: rk_servicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rk_servicio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idservicio,descripcion")] rk_servicio rk_servicio)
        {
            if (ModelState.IsValid)
            {
                db.rk_servicio.Add(rk_servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rk_servicio);
        }

        // GET: rk_servicio/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_servicio rk_servicio = db.rk_servicio.Find(id);
            if (rk_servicio == null)
            {
                return HttpNotFound();
            }
            return View(rk_servicio);
        }

        // POST: rk_servicio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idservicio,descripcion")] rk_servicio rk_servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rk_servicio);
        }

        // GET: rk_servicio/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_servicio rk_servicio = db.rk_servicio.Find(id);
            if (rk_servicio == null)
            {
                return HttpNotFound();
            }
            return View(rk_servicio);
        }

        // POST: rk_servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_servicio rk_servicio = db.rk_servicio.Find(id);
            db.rk_servicio.Remove(rk_servicio);
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
