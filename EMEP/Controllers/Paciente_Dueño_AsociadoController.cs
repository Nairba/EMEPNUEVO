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
    public class Paciente_Dueño_AsociadoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Paciente_Dueño_Asociado
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            return View(db.Paciente_Dueño_Asociado.ToList());
        }

        // GET: Paciente_Dueño_Asociado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Paciente.";
                return RedirectToAction("Index");
            }
            Paciente_Dueño_Asociado paciente_Dueño_Asociado = db.Paciente_Dueño_Asociado.Find(id);

            
            if (paciente_Dueño_Asociado == null)
            {
                TempData["mensaje"] = "No éxiste el Paciente.";
                return RedirectToAction("Index");
            }
            return View(paciente_Dueño_Asociado);
        }

        // GET: Paciente_Dueño_Asociado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paciente_Dueño_Asociado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente_Dueño_Asociado paciente_Dueño_Asociado)
        {
            try
            {
                db.Paciente_Dueño_Asociado.Add(paciente_Dueño_Asociado);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(paciente_Dueño_Asociado);
            }

        }

        // GET: Paciente_Dueño_Asociado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Paciente.";
                return RedirectToAction("Index");
            }
            Paciente_Dueño_Asociado paciente_Dueño_Asociado = db.Paciente_Dueño_Asociado.Find(id);
            if (paciente_Dueño_Asociado == null)
            {
                TempData["mensaje"] = "No éxiste el Paciente.";
                return RedirectToAction("Index");
            }
            return View(paciente_Dueño_Asociado);
        }

        // POST: Paciente_Dueño_Asociado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente_Dueño_Asociado paciente_Dueño_Asociado)
        {
            try
            {
                db.Entry(paciente_Dueño_Asociado).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Actializo con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(paciente_Dueño_Asociado);
            }

        }

        // GET: Paciente_Dueño_Asociado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Paciente.";
                return RedirectToAction("Index");
            }
            Paciente_Dueño_Asociado paciente_Dueño_Asociado = db.Paciente_Dueño_Asociado.Find(id);
            if (paciente_Dueño_Asociado == null)
            {
                TempData["mensaje"] = "No éxiste el Paciente.";
                return RedirectToAction("Index");
            }
            return View(paciente_Dueño_Asociado);
        }

        // POST: Paciente_Dueño_Asociado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente_Dueño_Asociado paciente_Dueño_Asociado = db.Paciente_Dueño_Asociado.Find(id);
            db.Paciente_Dueño_Asociado.Remove(paciente_Dueño_Asociado);
            db.SaveChanges();

            TempData["mensaje"] = "Se cambio la configuración con éxito.";
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
