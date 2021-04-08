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
    public class LinhasController : Controller
    {
        private ArthesContext db = new ArthesContext();

        // GET: Linhas
        public ActionResult Index()
        {
            var lINHAS = db.LINHAS.Include(l => l.Cor).Include(l => l.Fabricante).Include(l => l.TipoLinha);
            return View(lINHAS.ToList());
        }

        // GET: Linhas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linha linha = db.LINHAS.Find(id);
            if (linha == null)
            {
                return HttpNotFound();
            }
            return View(linha);
        }

        // GET: Linhas/Create
        public ActionResult Create()
        {
            ViewBag.CorID = new SelectList(db.CORES, "CorID", "Nome");
            ViewBag.FabricanteID = new SelectList(db.FABRICANTES, "FabricanteID", "Nome");
            ViewBag.TipoLinhaID = new SelectList(db.TIPOSLINHAS, "TipoLinhaID", "Nome");
            return View();
        }

        // POST: Linhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LinhaID,QtdFechada,QtdAberta,TipoLinhaID,FabricanteID,CorID")] Linha linha)
        {
            if (ModelState.IsValid)
            {
                db.LINHAS.Add(linha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CorID = new SelectList(db.CORES, "CorID", "Nome", linha.CorID);
            ViewBag.FabricanteID = new SelectList(db.FABRICANTES, "FabricanteID", "Nome", linha.FabricanteID);
            ViewBag.TipoLinhaID = new SelectList(db.TIPOSLINHAS, "TipoLinhaID", "Nome", linha.TipoLinhaID);
            return View(linha);
        }

        // GET: Linhas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linha linha = db.LINHAS.Find(id);
            if (linha == null)
            {
                return HttpNotFound();
            }
            ViewBag.CorID = new SelectList(db.CORES, "CorID", "Nome", linha.CorID);
            ViewBag.FabricanteID = new SelectList(db.FABRICANTES, "FabricanteID", "Nome", linha.FabricanteID);
            ViewBag.TipoLinhaID = new SelectList(db.TIPOSLINHAS, "TipoLinhaID", "Nome", linha.TipoLinhaID);
            return View(linha);
        }

        // POST: Linhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LinhaID,QtdFechada,QtdAberta,TipoLinhaID,FabricanteID,CorID")] Linha linha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CorID = new SelectList(db.CORES, "CorID", "Nome", linha.CorID);
            ViewBag.FabricanteID = new SelectList(db.FABRICANTES, "FabricanteID", "Nome", linha.FabricanteID);
            ViewBag.TipoLinhaID = new SelectList(db.TIPOSLINHAS, "TipoLinhaID", "Nome", linha.TipoLinhaID);
            return View(linha);
        }

        // GET: Linhas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linha linha = db.LINHAS.Find(id);
            if (linha == null)
            {
                return HttpNotFound();
            }
            return View(linha);
        }

        // POST: Linhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Linha linha = db.LINHAS.Find(id);
            db.LINHAS.Remove(linha);
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
