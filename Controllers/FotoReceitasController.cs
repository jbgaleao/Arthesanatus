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
    public class FotoReceitasController : Controller
    {
        private ArthesContext db = new ArthesContext();

        // GET: FotoReceitas
        public ActionResult Index()
        {
            var fOTOSRECEITAS = db.FOTOSRECEITAS.Include(f => f.Receita);
            return View(fOTOSRECEITAS.ToList());
        }

        // GET: FotoReceitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotoReceita fotoReceita = db.FOTOSRECEITAS.Find(id);
            if (fotoReceita == null)
            {
                return HttpNotFound();
            }
            return View(fotoReceita);
        }

        // GET: FotoReceitas/Create
        public ActionResult Create()
        {
            ViewBag.ReceitaId = new SelectList(db.RECEITAS, "ReceitaId", "Nome");
            return View();
        }

        // POST: FotoReceitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FotoReceitaId,Descricao,CaminhoFoto,ReceitaId")] FotoReceita fotoReceita)
        {
            if (ModelState.IsValid)
            {
                db.FOTOSRECEITAS.Add(fotoReceita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReceitaId = new SelectList(db.RECEITAS, "ReceitaId", "Nome", fotoReceita.ReceitaId);
            return View(fotoReceita);
        }

        // GET: FotoReceitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotoReceita fotoReceita = db.FOTOSRECEITAS.Find(id);
            if (fotoReceita == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReceitaId = new SelectList(db.RECEITAS, "ReceitaId", "Nome", fotoReceita.ReceitaId);
            return View(fotoReceita);
        }

        // POST: FotoReceitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FotoReceitaId,Descricao,CaminhoFoto,ReceitaId")] FotoReceita fotoReceita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fotoReceita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReceitaId = new SelectList(db.RECEITAS, "ReceitaId", "Nome", fotoReceita.ReceitaId);
            return View(fotoReceita);
        }

        // GET: FotoReceitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotoReceita fotoReceita = db.FOTOSRECEITAS.Find(id);
            if (fotoReceita == null)
            {
                return HttpNotFound();
            }
            return View(fotoReceita);
        }

        // POST: FotoReceitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FotoReceita fotoReceita = db.FOTOSRECEITAS.Find(id);
            db.FOTOSRECEITAS.Remove(fotoReceita);
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
