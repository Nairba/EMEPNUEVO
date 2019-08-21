using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMEP.Models;

namespace EMEP.Controllers
{
    public class Enfermedad_FamiliarController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        // GET: Enfermedad_Familiar
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var enfermedad_Familiar = db.Enfermedad_Familiar.Include(e => e.Expediente).Include(e => e.Lista_Enfermedad);
            return View(enfermedad_Familiar.ToList());
        }

        // GET: Enfermedad_Familiar/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                TempData["mensaje"] = "Especifique la Enfermedad.";
                return RedirectToAction("Index");
            }
            Enfermedad_Familiar enfermedad_Familiar = db.Enfermedad_Familiar.Find(id);
            if (enfermedad_Familiar == null)
            {
                TempData["mensaje"] = "La Enfermedad no éxiste.";
                return RedirectToAction("Index");
            }
            return View(enfermedad_Familiar);
        }

        // GET: Enfermedad_Familiar/Create
        public ActionResult Create()
        {
            ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE");
            ViewBag.ID_ENFERMEDAD = new SelectList(db.Lista_Enfermedad, "id", "descripcion");
            return View();
        }

        // POST: Enfermedad_Familiar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Enfermedad_Familiar enfermedad_Familiar)
        {
            try
            {
                db.Enfermedad_Familiar.Add(enfermedad_Familiar);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", enfermedad_Familiar.ID_EXPEDIENTE);
                ViewBag.ID_ENFERMEDAD = new SelectList(db.Lista_Enfermedad, "id", "descripcion", enfermedad_Familiar.ID_ENFERMEDAD);
                return View(enfermedad_Familiar);
            }
           
        }

        // GET: Enfermedad_Familiar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la Enfermedad.";
                return RedirectToAction("Index");
            }
            Enfermedad_Familiar enfermedad_Familiar = db.Enfermedad_Familiar.Find(id);
            if (enfermedad_Familiar == null)
            {
                TempData["mensaje"] = "La Enfermedad no éxiste.";
                return RedirectToAction("Index");
            }
            ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", enfermedad_Familiar.ID_EXPEDIENTE);
            ViewBag.ID_ENFERMEDAD = new SelectList(db.Lista_Enfermedad, "id", "descripcion", enfermedad_Familiar.ID_ENFERMEDAD);
            return View(enfermedad_Familiar);
        }

        // POST: Enfermedad_Familiar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,parentesco,observaciones,ID_EXPEDIENTE,ID_ENFERMEDAD")] Enfermedad_Familiar enfermedad_Familiar)
        {
           try
            {
                db.Entry(enfermedad_Familiar).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Actualizado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", enfermedad_Familiar.ID_EXPEDIENTE);
                ViewBag.ID_ENFERMEDAD = new SelectList(db.Lista_Enfermedad, "id", "descripcion", enfermedad_Familiar.ID_ENFERMEDAD);
                return View(enfermedad_Familiar);
            }
            
        }

        // GET: Enfermedad_Familiar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la Enfermedad.";
                return RedirectToAction("Index");
            }
            Enfermedad_Familiar enfermedad_Familiar = db.Enfermedad_Familiar.Find(id);
            if (enfermedad_Familiar == null)
            {
                TempData["mensaje"] = "La Enfermedad no éxiste.";
                return RedirectToAction("Index");
            }
            return View(enfermedad_Familiar);
        }

        // POST: Enfermedad_Familiar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enfermedad_Familiar enfermedad_Familiar = db.Enfermedad_Familiar.Find(id);
            db.Enfermedad_Familiar.Remove(enfermedad_Familiar);
            db.SaveChanges();
            TempData["mensaje"] = "Removida con exito.";
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
