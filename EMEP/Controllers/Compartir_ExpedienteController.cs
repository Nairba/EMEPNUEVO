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
    public class Compartir_ExpedienteController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        // GET: Compartir_Expediente
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var compartir_Expediente = db.Compartir_Expediente.Include(c => c.Paciente);
            return View(compartir_Expediente.ToList());
        }

        // GET: Compartir_Expediente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la acción.";
                return RedirectToAction("Index");
            }
            Compartir_Expediente compartir = db.Compartir_Expediente.Find(id);
            if (compartir != null)
            {
                if (compartir.estado == 1)
                {
                    compartir.estado_String = "Activo";
                }
                else
                {
                    compartir.estado_String = "Inactivo";
                }
            }
            if (compartir == null)
            {
                TempData["mensaje"] = "La acción no éxiste.";
                return RedirectToAction("Index");
            }
            return View(compartir);
        }

        // GET: Compartir_Expediente/Create
        public ActionResult Create()
        {
            ViewBag.ID_PACIENTE = new SelectList(db.Paciente, "correo", "cedula");
            return View();
        }

        // POST: Compartir_Expediente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compartir_Expediente compartir_Expediente)
        {
          try
            {
                compartir_Expediente.estado = 1;
                db.Compartir_Expediente.Add(compartir_Expediente);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ID_PACIENTE = new SelectList(db.Paciente, "correo", "cedula", compartir_Expediente.ID_PACIENTE);
                return View(compartir_Expediente);
            }
            
        }

        // GET: Compartir_Expediente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la acción.";
                return RedirectToAction("Index");
            }
            Compartir_Expediente compartir = db.Compartir_Expediente.Find(id);
            if (compartir != null)
            {
                if (compartir.estado == 1)
                {
                    compartir.estado_String = "Activo";
                }
                else
                {
                    compartir.estado_String = "Inactivo";
                }
            }
            if (compartir == null)
            {
                TempData["mensaje"] = "La acción no éxiste.";
                return RedirectToAction("Index");
            }
            return View(compartir);
        }

        // POST: Compartir_Expediente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Compartir_Expediente compartir_Expediente)
        {
            try
            {
                db.Entry(compartir_Expediente).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Actulización con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {

                ViewBag.ID_PACIENTE = new SelectList(db.Paciente, "correo", "cedula", compartir_Expediente.ID_PACIENTE);
                return View(compartir_Expediente);
            }
        }

        // GET: Compartir_Expediente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la acción.";
                return RedirectToAction("Index");
            }
            Compartir_Expediente compartir = db.Compartir_Expediente.Find(id);
            if (compartir != null)
            {
                if (compartir.estado == 1)
                {
                    compartir.estado_String = "Activo";
                }
                else
                {
                    compartir.estado_String = "Inactivo";
                }
            }
            if (compartir == null)
            {
                TempData["mensaje"] = "La acción no éxiste.";
                return RedirectToAction("Index");
            }
            return View(compartir);
        }

        // POST: Compartir_Expediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compartir_Expediente compartir = db.Compartir_Expediente.Find(id);
            if (compartir.estado == 0)
            {
                compartir.estado = 1;
            }
            else
            {
                compartir.estado = 0;
            }
            db.SaveChanges();
            TempData["mensaje"] = "Estado actualizado.";
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
