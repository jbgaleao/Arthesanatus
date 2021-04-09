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
    public class CoresController:Controller
    {
        private ArthesContext db = new ArthesContext();

        // GET: Cores
        public ActionResult Index(string ChaveBusca = "")
        {
            var q = db.CORES.AsQueryable();

            if(!string.IsNullOrEmpty(ChaveBusca))
            {
                q = q.Where(p => p.Nome.Contains(ChaveBusca));
            }

            q = q.OrderBy(p => p.Nome);

            return View(q.ToList());
        }

        // GET: Cores/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.CORES.Find(id);
            if(cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // GET: Cores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CorID,CorCodigo,Nome")] Cor cor)
        {
            if(ModelState.IsValid)
            {
                db.CORES.Add(cor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cor);
        }

        // GET: Cores/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.CORES.Find(id);
            if(cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // POST: Cores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CorID,CorCodigo,Nome")] Cor cor)
        {
            if(ModelState.IsValid)
            {
                db.Entry(cor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cor);
        }

        // GET: Cores/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.CORES.Find(id);
            if(cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // POST: Cores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cor cor = db.CORES.Find(id);
            db.CORES.Remove(cor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IEnumerable<Cor> TestaCores()
        {
            var query = (from c in db.CORES
                         where c.Nome.Contains("ama")
                         select c);

            return query;

        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
