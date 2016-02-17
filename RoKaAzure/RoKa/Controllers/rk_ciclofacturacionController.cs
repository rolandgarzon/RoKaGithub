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
    public class rk_ciclofacturacionController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_ciclofacturacion
        public ActionResult Index()
        {
            var rk_ciclofacturacion = db.rk_ciclofacturacion.Include(r => r.rk_departamento).Include(r => r.rk_municipio).Include(r => r.rk_pais);
            return View(rk_ciclofacturacion.ToList());
        }

        // GET: rk_ciclofacturacion/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_ciclofacturacion rk_ciclofacturacion = db.rk_ciclofacturacion.Find(id);
            if (rk_ciclofacturacion == null)
            {
                return HttpNotFound();
            }
            return View(rk_ciclofacturacion);
        }

        // GET: rk_ciclofacturacion/Create
        public ActionResult Create()
        {
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion");
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion");
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion");
            return View();
        }

        // POST: rk_ciclofacturacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idciclofacturacion,descripcion,idpais,iddepartamento,idmunicipio")] rk_ciclofacturacion rk_ciclofacturacion)
        {
            if (ModelState.IsValid)
            {
                db.rk_ciclofacturacion.Add(rk_ciclofacturacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_ciclofacturacion.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_ciclofacturacion.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_ciclofacturacion.idpais);
            return View(rk_ciclofacturacion);
        }

        // GET: rk_ciclofacturacion/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_ciclofacturacion rk_ciclofacturacion = db.rk_ciclofacturacion.Find(id);
            if (rk_ciclofacturacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_ciclofacturacion.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_ciclofacturacion.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_ciclofacturacion.idpais);
            return View(rk_ciclofacturacion);
        }

        // POST: rk_ciclofacturacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idciclofacturacion,descripcion,idpais,iddepartamento,idmunicipio")] rk_ciclofacturacion rk_ciclofacturacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_ciclofacturacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_ciclofacturacion.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_ciclofacturacion.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_ciclofacturacion.idpais);
            return View(rk_ciclofacturacion);
        }

        // GET: rk_ciclofacturacion/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_ciclofacturacion rk_ciclofacturacion = db.rk_ciclofacturacion.Find(id);
            if (rk_ciclofacturacion == null)
            {
                return HttpNotFound();
            }
            return View(rk_ciclofacturacion);
        }

        // POST: rk_ciclofacturacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_ciclofacturacion rk_ciclofacturacion = db.rk_ciclofacturacion.Find(id);
            db.rk_ciclofacturacion.Remove(rk_ciclofacturacion);
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
