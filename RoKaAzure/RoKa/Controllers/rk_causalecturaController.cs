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
    public class rk_causalecturaController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_causalectura
        public ActionResult Index()
        {
            var rk_causalectura = db.rk_causalectura.Include(r => r.rk_servicio);
            return View(rk_causalectura.ToList());
        }

        // GET: rk_causalectura/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_causalectura rk_causalectura = db.rk_causalectura.Find(id);
            if (rk_causalectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_causalectura);
        }

        // GET: rk_causalectura/Create
        public ActionResult Create()
        {
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion");
            return View();
        }

        // POST: rk_causalectura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcausalectura,descripcion,idservicio")] rk_causalectura rk_causalectura)
        {
            if (ModelState.IsValid)
            {
                db.rk_causalectura.Add(rk_causalectura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_causalectura.idservicio);
            return View(rk_causalectura);
        }

        // GET: rk_causalectura/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_causalectura rk_causalectura = db.rk_causalectura.Find(id);
            if (rk_causalectura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_causalectura.idservicio);
            return View(rk_causalectura);
        }

        // POST: rk_causalectura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcausalectura,descripcion,idservicio")] rk_causalectura rk_causalectura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_causalectura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_causalectura.idservicio);
            return View(rk_causalectura);
        }

        // GET: rk_causalectura/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_causalectura rk_causalectura = db.rk_causalectura.Find(id);
            if (rk_causalectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_causalectura);
        }

        // POST: rk_causalectura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_causalectura rk_causalectura = db.rk_causalectura.Find(id);
            db.rk_causalectura.Remove(rk_causalectura);
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
