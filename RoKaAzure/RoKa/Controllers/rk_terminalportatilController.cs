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
    public class rk_terminalportatilController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_terminalportatil
        public ActionResult Index()
        {
            return View(db.rk_terminalportatil.ToList());
        }

        // GET: rk_terminalportatil/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_terminalportatil rk_terminalportatil = db.rk_terminalportatil.Find(id);
            if (rk_terminalportatil == null)
            {
                return HttpNotFound();
            }
            return View(rk_terminalportatil);
        }

        // GET: rk_terminalportatil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rk_terminalportatil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idterminalportatil,serie,marca,modelo,numerocelular,imei")] rk_terminalportatil rk_terminalportatil)
        {
            if (ModelState.IsValid)
            {
                db.rk_terminalportatil.Add(rk_terminalportatil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rk_terminalportatil);
        }

        // GET: rk_terminalportatil/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_terminalportatil rk_terminalportatil = db.rk_terminalportatil.Find(id);
            if (rk_terminalportatil == null)
            {
                return HttpNotFound();
            }
            return View(rk_terminalportatil);
        }

        // POST: rk_terminalportatil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idterminalportatil,serie,marca,modelo,numerocelular,imei")] rk_terminalportatil rk_terminalportatil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_terminalportatil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rk_terminalportatil);
        }

        // GET: rk_terminalportatil/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_terminalportatil rk_terminalportatil = db.rk_terminalportatil.Find(id);
            if (rk_terminalportatil == null)
            {
                return HttpNotFound();
            }
            return View(rk_terminalportatil);
        }

        // POST: rk_terminalportatil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_terminalportatil rk_terminalportatil = db.rk_terminalportatil.Find(id);
            db.rk_terminalportatil.Remove(rk_terminalportatil);
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
