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
    public class rk_usuarioController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_usuario
        public ActionResult Index()
        {
            var rk_usuario = db.rk_usuario.Include(r => r.rk_departamento).Include(r => r.rk_pais);
            return View(rk_usuario.ToList());
        }

        // GET: rk_usuario/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_usuario rk_usuario = db.rk_usuario.Find(id);
            if (rk_usuario == null)
            {
                return HttpNotFound();
            }
            return View(rk_usuario);
        }

        // GET: rk_usuario/Create
        public ActionResult Create()
        {
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion");
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion");
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion");
            return View();
        }

        // POST: rk_usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idusuario,nombrecompleto,email,idpais,iddepartamento,idmunicipio")] rk_usuario rk_usuario)
        {
            if (ModelState.IsValid)
            {
                rk_usuario.activo = "s";
                db.rk_usuario.Add(rk_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion");
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_usuario.iddepartamento);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_usuario.idpais);
            return View(rk_usuario);
        }

        // GET: rk_usuario/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_usuario rk_usuario = db.rk_usuario.Find(id);
            if (rk_usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_usuario.iddepartamento);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_usuario.idpais);
            return View(rk_usuario);
        }

        // POST: rk_usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idusuario,nombrecompleto,email,idpais,iddepartamento,idmunicipio")] rk_usuario rk_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_usuario.iddepartamento);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_usuario.idpais);
            return View(rk_usuario);
        }

        // GET: rk_usuario/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_usuario rk_usuario = db.rk_usuario.Find(id);
            if (rk_usuario == null)
            {
                return HttpNotFound();
            }
            return View(rk_usuario);
        }

        // POST: rk_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_usuario rk_usuario = db.rk_usuario.Find(id);
            db.rk_usuario.Remove(rk_usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: rk_usuario/Consulta Manual
        public ActionResult ConsultaManual()
        {
            return View();
        }

        // POST: rk_usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConsultaManual(string idusuario)
        {
            rk_usuario objrk_usuario = db.rk_usuario.Find(idusuario);
            if (objrk_usuario==null)
            {
                ViewBag.informe = "el usuario no existe";
            }
            return View(objrk_usuario);
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
