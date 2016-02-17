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
    public class rk_paisController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_pais
        public ActionResult Index()
        {
            return View(db.rk_pais.ToList());
        }

        // GET: rk_pais/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_pais rk_pais = db.rk_pais.Find(id);
            if (rk_pais == null)
            {
                return HttpNotFound();
            }
            return View(rk_pais);
        }

        // GET: rk_pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rk_pais/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idpais,descripcion")] rk_pais rk_pais)
        {
            if (ModelState.IsValid)
            {
                db.rk_pais.Add(rk_pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rk_pais);
        }

        // GET: rk_pais/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_pais rk_pais = db.rk_pais.Find(id);
            if (rk_pais == null)
            {
                return HttpNotFound();
            }
            return View(rk_pais);
        }

        // POST: rk_pais/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idpais,descripcion")] rk_pais rk_pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rk_pais);
        }

        // GET: rk_pais/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_pais rk_pais = db.rk_pais.Find(id);
            if (rk_pais == null)
            {
                return HttpNotFound();
            }
            return View(rk_pais);
        }

        // POST: rk_pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_pais rk_pais = db.rk_pais.Find(id);
            db.rk_pais.Remove(rk_pais);
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
