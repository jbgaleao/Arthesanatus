using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Arthesanatus.Models;
using Arthesanatus.Models.Context;
using Arthesanatus.Util;

namespace Arthesanatus.Controllers
{
    public class RevistasController:Controller
    {
        private ArthesContext db = new ArthesContext();


        public ActionResult Index()
        {
            return View(db.REVISTAS.ToList());
        }


        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.REVISTAS.Find(id);
            if(revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Revista revista)
        {
            if(ModelState.IsValid)
            {
                if(revista.ArquivoFoto != null)
                {
                    revista.Foto = FilesHelper.UploadPhoto(revista.ArquivoFoto);
                }
                db.REVISTAS.Add(revista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(revista);
        }


        public ActionResult Edit(int? id)
       {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.REVISTAS.Find(id);
            if(revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RevistaID,NumeroEdicao,AnoEdicao,MesEdicao,Tema,Foto")] Revista revista)
        {
            if(ModelState.IsValid)
            {
                db.Entry(revista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(revista);
        }


        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = db.REVISTAS.Find(id);
            if(revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Revista revista = db.REVISTAS.Find(id);
            db.REVISTAS.Remove(revista);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RevistasReceitasVM(int codRevista,string temaRevista){
        
             List<Receita> receita = (from rec in db.RECEITAS
                        where rec.RevistaId.Equals(codRevista)
                        select rec).ToList();

            Revista revista = db.REVISTAS.Find(codRevista);

            ViewBag.rev = revista;

            return View(receita);

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
