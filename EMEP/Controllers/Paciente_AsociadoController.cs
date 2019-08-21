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
    public class Paciente_AsociadoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Paciente_Asociado
        public ActionResult Index()
        {
            return View(db.Paciente_Asociado.ToList());
        }

        // GET: Paciente_Asociado/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente_Asociado paciente_Asociado = db.Paciente_Asociado.Find(id);
            if (paciente_Asociado == null)
            {
                return HttpNotFound();
            }
            return View(paciente_Asociado);
        }

        // GET: Paciente_Asociado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paciente_Asociado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "correo,cedula,nombre,p_Apellido,s_Apellido,contrasenna,sexo,estado,estad,estado_String,fecha_nacimiento,tipo_sangre,recidencia,telefono,contacto_emergencia,parentesco,ID_TIPO_USUARIO")] Paciente_Asociado paciente_Asociado)
        {
            if (ModelState.IsValid)
            {
                db.Paciente_Asociado.Add(paciente_Asociado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paciente_Asociado);
        }

        // GET: Paciente_Asociado/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente_Asociado paciente_Asociado = db.Paciente_Asociado.Find(id);
            if (paciente_Asociado == null)
            {
                return HttpNotFound();
            }
            return View(paciente_Asociado);
        }

        // POST: Paciente_Asociado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "correo,cedula,nombre,p_Apellido,s_Apellido,contrasenna,sexo,estado,estad,estado_String,fecha_nacimiento,tipo_sangre,recidencia,telefono,contacto_emergencia,parentesco,ID_TIPO_USUARIO")] Paciente_Asociado paciente_Asociado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente_Asociado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente_Asociado);
        }

        // GET: Paciente_Asociado/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente_Asociado paciente_Asociado = db.Paciente_Asociado.Find(id);
            if (paciente_Asociado == null)
            {
                return HttpNotFound();
            }
            return View(paciente_Asociado);
        }

        // POST: Paciente_Asociado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Paciente_Asociado paciente_Asociado = db.Paciente_Asociado.Find(id);
            db.Paciente_Asociado.Remove(paciente_Asociado);
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
