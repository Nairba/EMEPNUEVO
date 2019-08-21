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
    public class HorarioController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        // GET: Horario
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            return View(db.Horario.ToList());
        }

        // GET: Horario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Horario.";
                return RedirectToAction("Index");
            }
            Horario horario = db.Horario.Find(id);
            if (horario != null)
            {
                if (horario.estado == 1)
                {
                    horario.estado_String = "Activo";
                }
                else
                {
                    horario.estado_String = "Inactivo";
                }
            }
            if (horario == null)
            {
                TempData["mensaje"] = "No éxite el Horario.";
                return RedirectToAction("Index");
            }
            return View(horario);
        }

        // GET: Horario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Horario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Horario horario)
        {
            try
            {
                horario.estado = 1;
                db.Horario.Add(horario);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(horario);
            }

        }

        // GET: Horario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Horario.";
                return RedirectToAction("Index");
            }
            Horario horario = db.Horario.Find(id);
            if (horario != null)
            {
                if (horario.estado == 1)
                {
                    horario.estado_String = "Activo";
                }
                else
                {
                    horario.estado_String = "Inactivo";
                }
            }
            if (horario == null)
            {
                TempData["mensaje"] = "No éxite el Horario.";
                return RedirectToAction("Index");
            }
            return View(horario);
        }

        // POST: Horario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Horario horario)
        {
            try
            {
                db.Entry(horario).State = EntityState.Modified;
                db.SaveChanges();

                TempData["mensaje"] = "Actualizado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(horario);
            }
            
        }

        // GET: Horario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Horario.";
                return RedirectToAction("Index");
            }
            Horario horario = db.Horario.Find(id);
            if (horario != null)
            {
                if (horario.estado == 1)
                {
                    horario.estado_String = "Activo";
                }
                else
                {
                    horario.estado_String = "Inactivo";
                }
            }
            if (horario == null)
            {
                TempData["mensaje"] = "No éxite el Horario.";
                return RedirectToAction("Index");
            }
            return View(horario);
        }

        // POST: Horario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horario horario = db.Horario.Find(id);
            if (horario.estado == 0)
            {
                horario.estado = 1;
            }
            else
            {
                horario.estado = 0;
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
