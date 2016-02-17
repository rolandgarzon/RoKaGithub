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
    public class rk_reglasdecriticaController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_reglasdecritica
        public ActionResult Index()
        {
            var rk_reglasdecritica = db.rk_reglasdecritica.Include(r => r.rk_departamento).Include(r => r.rk_municipio).Include(r => r.rk_pais).Include(r => r.rk_servicio);
            return View(rk_reglasdecritica.ToList());
        }

        // GET: rk_reglasdecritica/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_reglasdecritica rk_reglasdecritica = db.rk_reglasdecritica.Find(id);
            if (rk_reglasdecritica == null)
            {
                return HttpNotFound();
            }
            return View(rk_reglasdecritica);
        }

        // GET: rk_reglasdecritica/Create
        public ActionResult Create()
        {
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion");
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion");
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion");
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion");
            return View();
        }

        // POST: rk_reglasdecritica/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idreglascritica,idservicio,consumoinicial,consumofinal,porcentajearriba,porcentajeabajo,idpais,iddepartamento,idmunicipio")] rk_reglasdecritica rk_reglasdecritica)
        {
            if (ModelState.IsValid)
            {
                db.rk_reglasdecritica.Add(rk_reglasdecritica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_reglasdecritica.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_reglasdecritica.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_reglasdecritica.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_reglasdecritica.idservicio);
            return View(rk_reglasdecritica);
        }

        // GET: rk_reglasdecritica/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_reglasdecritica rk_reglasdecritica = db.rk_reglasdecritica.Find(id);
            if (rk_reglasdecritica == null)
            {
                return HttpNotFound();
            }
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_reglasdecritica.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_reglasdecritica.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_reglasdecritica.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_reglasdecritica.idservicio);
            return View(rk_reglasdecritica);
        }

        // POST: rk_reglasdecritica/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idreglascritica,idservicio,consumoinicial,consumofinal,porcentajearriba,porcentajeabajo,idpais,iddepartamento,idmunicipio")] rk_reglasdecritica rk_reglasdecritica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_reglasdecritica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_reglasdecritica.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_reglasdecritica.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_reglasdecritica.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_reglasdecritica.idservicio);
            return View(rk_reglasdecritica);
        }

        // GET: rk_reglasdecritica/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_reglasdecritica rk_reglasdecritica = db.rk_reglasdecritica.Find(id);
            if (rk_reglasdecritica == null)
            {
                return HttpNotFound();
            }
            return View(rk_reglasdecritica);
        }

        // POST: rk_reglasdecritica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_reglasdecritica rk_reglasdecritica = db.rk_reglasdecritica.Find(id);
            db.rk_reglasdecritica.Remove(rk_reglasdecritica);
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
