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
    public class rk_grupolecturaController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_grupolectura
        public ActionResult Index()
        {
            var rk_grupolectura = db.rk_grupolectura.Include(r => r.rk_ciclofacturacion).Include(r => r.rk_departamento).Include(r => r.rk_municipio).Include(r => r.rk_pais).Include(r => r.rk_servicio);
            return View(rk_grupolectura.ToList());
        }

        // GET: rk_grupolectura/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_grupolectura rk_grupolectura = db.rk_grupolectura.Find(id);
            if (rk_grupolectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_grupolectura);
        }

        // GET: rk_grupolectura/Create
        public ActionResult Create()
        {
            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion");
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion");
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion");
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion");
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion");
            return View();
        }

        // POST: rk_grupolectura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idgrupolectura,idservicio,idciclofacturacion,rutainicial,rutafinal,idpais,iddepartamento,idmunicipio")] rk_grupolectura rk_grupolectura)
        {
            if (ModelState.IsValid)
            {
                db.rk_grupolectura.Add(rk_grupolectura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion", rk_grupolectura.idciclofacturacion);
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_grupolectura.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_grupolectura.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_grupolectura.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_grupolectura.idservicio);
            return View(rk_grupolectura);
        }

        // GET: rk_grupolectura/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_grupolectura rk_grupolectura = db.rk_grupolectura.Find(id);
            if (rk_grupolectura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion", rk_grupolectura.idciclofacturacion);
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_grupolectura.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_grupolectura.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_grupolectura.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_grupolectura.idservicio);
            return View(rk_grupolectura);
        }

        // POST: rk_grupolectura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idgrupolectura,idservicio,idciclofacturacion,rutainicial,rutafinal,idpais,iddepartamento,idmunicipio")] rk_grupolectura rk_grupolectura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_grupolectura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion", rk_grupolectura.idciclofacturacion);
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_grupolectura.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_grupolectura.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_grupolectura.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_grupolectura.idservicio);
            return View(rk_grupolectura);
        }

        // GET: rk_grupolectura/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_grupolectura rk_grupolectura = db.rk_grupolectura.Find(id);
            if (rk_grupolectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_grupolectura);
        }

        // POST: rk_grupolectura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_grupolectura rk_grupolectura = db.rk_grupolectura.Find(id);
            db.rk_grupolectura.Remove(rk_grupolectura);
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
