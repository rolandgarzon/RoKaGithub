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
    public class rk_tecnicoController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_tecnico
        public ActionResult Index()
        {
            var rk_tecnico = db.rk_tecnico.Include(r => r.rk_departamento).Include(r => r.rk_municipio).Include(r => r.rk_pais);
            return View(rk_tecnico.ToList());
        }

        // GET: rk_tecnico/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_tecnico rk_tecnico = db.rk_tecnico.Find(id);
            if (rk_tecnico == null)
            {
                return HttpNotFound();
            }
            return View(rk_tecnico);
        }

        // GET: rk_tecnico/Create
        public ActionResult Create()
        {
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion");
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion");
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion");
            return View();
        }

        // POST: rk_tecnico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtecnico,identificacion,descripcion,telefono,activo,idpais,iddepartamento,idmunicipio")] rk_tecnico rk_tecnico)
        {
            if (ModelState.IsValid)
            {
                db.rk_tecnico.Add(rk_tecnico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_tecnico.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_tecnico.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_tecnico.idpais);
            return View(rk_tecnico);
        }

        // GET: rk_tecnico/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_tecnico rk_tecnico = db.rk_tecnico.Find(id);
            if (rk_tecnico == null)
            {
                return HttpNotFound();
            }
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_tecnico.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_tecnico.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_tecnico.idpais);
            return View(rk_tecnico);
        }

        // POST: rk_tecnico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtecnico,identificacion,descripcion,telefono,activo,idpais,iddepartamento,idmunicipio")] rk_tecnico rk_tecnico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_tecnico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_tecnico.iddepartamento);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_tecnico.idmunicipio);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_tecnico.idpais);
            return View(rk_tecnico);
        }

        // GET: rk_tecnico/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_tecnico rk_tecnico = db.rk_tecnico.Find(id);
            if (rk_tecnico == null)
            {
                return HttpNotFound();
            }
            return View(rk_tecnico);
        }

        // POST: rk_tecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_tecnico rk_tecnico = db.rk_tecnico.Find(id);
            db.rk_tecnico.Remove(rk_tecnico);
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
