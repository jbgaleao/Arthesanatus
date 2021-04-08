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
    public class TiposLinhaController : Controller
    {
        private ArthesContext db = new ArthesContext();

        // GET: TiposLinha
        public ActionResult Index()
        {
            return View(db.TIPOSLINHAS.ToList());
        }

        // GET: TiposLinha/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinha tipoLinha = db.TIPOSLINHAS.Find(id);
            if (tipoLinha == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinha);
        }

        // GET: TiposLinha/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposLinha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoLinhaID,Nome,Descricao,DadosTecnicos")] TipoLinha tipoLinha)
        {
            if (ModelState.IsValid)
            {
                db.TIPOSLINHAS.Add(tipoLinha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoLinha);
        }

        // GET: TiposLinha/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinha tipoLinha = db.TIPOSLINHAS.Find(id);
            if (tipoLinha == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinha);
        }

        // POST: TiposLinha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoLinhaID,Nome,Descricao,DadosTecnicos")] TipoLinha tipoLinha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoLinha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoLinha);
        }

        // GET: TiposLinha/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinha tipoLinha = db.TIPOSLINHAS.Find(id);
            if (tipoLinha == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinha);
        }

        // POST: TiposLinha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoLinha tipoLinha = db.TIPOSLINHAS.Find(id);
            db.TIPOSLINHAS.Remove(tipoLinha);
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
