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
    public class rk_criticaController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_critica
        public ActionResult Index()
        {
            var rk_critica = db.rk_critica.Include(r => r.rk_ciclofacturacion).Include(r => r.rk_departamento).Include(r => r.rk_municipio).Include(r => r.rk_pais).Include(r => r.rk_servicio).Include(r => r.rk_usuario);
            return View(rk_critica.ToList());
        }

        // GET: rk_critica/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_critica rk_critica = db.rk_critica.Find(id);
            if (rk_critica == null)
            {
                return HttpNotFound();
            }
            return View(rk_critica);
        }

        // GET: rk_critica/Create
        public ActionResult Create()
        {
            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion");
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion");
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion");
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion");
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion");
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto");
            return View();
        }

        // POST: rk_critica/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcritica,idservicio,idciclofacturacion,ano,mes,idsuscriptor,direccion,idmedidor,rutalectura,lecturaanterior,lecturaactual,consumoanterior,consumopromedio,consumoactual,idobservacionanterior,idobservacionactual,idmunicipio,iddepartamento,idpais,idusuario")] rk_critica rk_critica)
        {
            if (ModelState.IsValid)
            {
                db.rk_critica.Add(rk_critica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion", rk_critica.idciclofacturacion);
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_critica.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_critica.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_critica.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_critica.idservicio);
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto", rk_critica.idusuario);
            return View(rk_critica);
        }

        // GET: rk_critica/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_critica rk_critica = db.rk_critica.Find(id);
            if (rk_critica == null)
            {
                return HttpNotFound();
            }
            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion", rk_critica.idciclofacturacion);
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_critica.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_critica.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_critica.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_critica.idservicio);
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto", rk_critica.idusuario);
            return View(rk_critica);
        }

        // POST: rk_critica/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcritica,idservicio,idciclofacturacion,ano,mes,idsuscriptor,direccion,idmedidor,rutalectura,lecturaanterior,lecturaactual,consumoanterior,consumopromedio,consumoactual,idobservacionanterior,idobservacionactual,idmunicipio,iddepartamento,idpais,idusuario")] rk_critica rk_critica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_critica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion", rk_critica.idciclofacturacion);
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_critica.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_critica.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_critica.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_critica.idservicio);
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto", rk_critica.idusuario);
            return View(rk_critica);
        }

        // GET: rk_critica/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_critica rk_critica = db.rk_critica.Find(id);
            if (rk_critica == null)
            {
                return HttpNotFound();
            }
            return View(rk_critica);
        }

        // POST: rk_critica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_critica rk_critica = db.rk_critica.Find(id);
            db.rk_critica.Remove(rk_critica);
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
