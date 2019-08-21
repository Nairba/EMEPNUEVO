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
    public class Datos_PacienteController : Controller
    {
        private EMEPEntities db = new EMEPEntities();
        public static List<Datos_Paciente> listaDatos = new List<Datos_Paciente>();

        // GET: Datos_Paciente
        public ActionResult Index()
        {
           
            return View(db.Datos_Paciente.ToList());
            
        }

        // GET: Datos_Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos_Paciente datos_Paciente = db.Datos_Paciente.Find(id);
            if (datos_Paciente == null)
            {
                return HttpNotFound();
            }
            return View(datos_Paciente);
        }

        // GET: Datos_Paciente/Create
        public ActionResult CreateDatos()
        {
            return View();
        }

        // POST: Datos_Paciente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDatos(Datos_Paciente datos_Paciente)
        {
            if (ModelState.IsValid)
            {
                listaDatos.Add(datos_Paciente);
                db.Datos_Paciente.Add(datos_Paciente);
                db.SaveChanges();
                return RedirectToAction("CreateDatos");
            }

            return View(datos_Paciente);
        }

        // GET: Datos_Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos_Paciente datos_Paciente = db.Datos_Paciente.Find(id);
            if (datos_Paciente == null)
            {
                return HttpNotFound();
            }
            return View(datos_Paciente);
        }

        // POST: Datos_Paciente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha_nacimiento,tipo_sangre,recidencia,telefono,contacto_emergencia,parentesco")] Datos_Paciente datos_Paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datos_Paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datos_Paciente);
        }

        // GET: Datos_Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos_Paciente datos_Paciente = db.Datos_Paciente.Find(id);
            if (datos_Paciente == null)
            {
                return HttpNotFound();
            }
            return View(datos_Paciente);
        }

        // POST: Datos_Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Datos_Paciente datos_Paciente = db.Datos_Paciente.Find(id);
            db.Datos_Paciente.Remove(datos_Paciente);
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
