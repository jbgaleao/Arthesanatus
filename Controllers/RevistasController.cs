using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Arthesanatus.Models;
using Arthesanatus.Models.Context;

namespace Arthesanatus.Controllers
{
    public class RevistasController : Controller
    {
        private ArthesContext db = new ArthesContext();

        // GET: Revistas
        public ActionResult Index()
        {
            return View(db.REVISTAS.ToList());
        }

        // GET: Revistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.REVISTAS.Find(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        // GET: Revistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Revistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RevistaID,NumeroEdicao,AnoEdicao,MesEdicao,Tema,Foto")] Revista revista)
        {
            if (ModelState.IsValid)
            {
                db.REVISTAS.Add(revista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(revista);
        }

        // GET: Revistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.REVISTAS.Find(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        // POST: Revistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RevistaID,NumeroEdicao,AnoEdicao,MesEdicao,Tema,Foto")] Revista revista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(revista);
        }

        // GET: Revistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.REVISTAS.Find(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        // POST: Revistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Revista revista = db.REVISTAS.Find(id);
            db.REVISTAS.Remove(revista);
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
