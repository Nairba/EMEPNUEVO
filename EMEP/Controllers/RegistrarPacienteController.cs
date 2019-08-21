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
    public class RegistrarPacienteController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        public static List<Paciente> listaPaciente = new List<Paciente>();
        public static List<Datos_Paciente> listaDatos = new List<Datos_Paciente>();

        // GET: RegistrarPaciente
        public ActionResult Index()
        {
            var paciente_Paciente_Asociado = db.Paciente_Paciente_Asociado.Include(p => p.Datos_Paciente).Include(p => p.Paciente);
            return View(paciente_Paciente_Asociado.ToList());
        }




        public ActionResult RegistrarPaciente(Paciente paciente)
        {
            if (paciente!=null)
            {
                if (ModelState.IsValid)
                {
                    // PacienteController.listaPaciente1.Add(paciente);
                    // listaPaciente.Add(paciente);
                    return PartialView("_RegistraPaciente_");
                }
                return View();
            }
           
            ViewBag.listaTipo = new SelectList(db.Tipo_Usuario, "id", "descripcion", paciente.ID_TIPO_USUARIO);
            return View();
        }

        // GET: RegistrarPaciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente_Paciente_Asociado paciente_Paciente_Asociado = db.Paciente_Paciente_Asociado.Find(id);
            if (paciente_Paciente_Asociado == null)
            {
                return HttpNotFound();
            }
            return View(paciente_Paciente_Asociado);
        }

        // GET: RegistrarPaciente/Create
        public ActionResult Create()
        {
            ViewBag.ID_PACIENTE_ASOCIADO = new SelectList(db.Datos_Paciente, "id", "tipo_sangre");
            ViewBag.ID_PACIENTE = new SelectList(db.Paciente, "correo", "cedula");
            return View();
        }

        // POST: RegistrarPaciente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PACIENTE,ID_PACIENTE_ASOCIADO,id")] Paciente_Paciente_Asociado paciente_Paciente_Asociado)
        {
            if (ModelState.IsValid)
            {
                db.Paciente_Paciente_Asociado.Add(paciente_Paciente_Asociado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PACIENTE_ASOCIADO = new SelectList(db.Datos_Paciente, "id", "tipo_sangre", paciente_Paciente_Asociado.ID_PACIENTE_ASOCIADO);
            ViewBag.ID_PACIENTE = new SelectList(db.Paciente, "correo", "cedula", paciente_Paciente_Asociado.ID_PACIENTE);
            return View(paciente_Paciente_Asociado);
        }

        // GET: RegistrarPaciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente_Paciente_Asociado paciente_Paciente_Asociado = db.Paciente_Paciente_Asociado.Find(id);
            if (paciente_Paciente_Asociado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PACIENTE_ASOCIADO = new SelectList(db.Datos_Paciente, "id", "tipo_sangre", paciente_Paciente_Asociado.ID_PACIENTE_ASOCIADO);
            ViewBag.ID_PACIENTE = new SelectList(db.Paciente, "correo", "cedula", paciente_Paciente_Asociado.ID_PACIENTE);
            return View(paciente_Paciente_Asociado);
        }

        // POST: RegistrarPaciente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PACIENTE,ID_PACIENTE_ASOCIADO,id")] Paciente_Paciente_Asociado paciente_Paciente_Asociado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente_Paciente_Asociado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PACIENTE_ASOCIADO = new SelectList(db.Datos_Paciente, "id", "tipo_sangre", paciente_Paciente_Asociado.ID_PACIENTE_ASOCIADO);
            ViewBag.ID_PACIENTE = new SelectList(db.Paciente, "correo", "cedula", paciente_Paciente_Asociado.ID_PACIENTE);
            return View(paciente_Paciente_Asociado);
        }

        // GET: RegistrarPaciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente_Paciente_Asociado paciente_Paciente_Asociado = db.Paciente_Paciente_Asociado.Find(id);
            if (paciente_Paciente_Asociado == null)
            {
                return HttpNotFound();
            }
            return View(paciente_Paciente_Asociado);
        }

        // POST: RegistrarPaciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente_Paciente_Asociado paciente_Paciente_Asociado = db.Paciente_Paciente_Asociado.Find(id);
            db.Paciente_Paciente_Asociado.Remove(paciente_Paciente_Asociado);
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
