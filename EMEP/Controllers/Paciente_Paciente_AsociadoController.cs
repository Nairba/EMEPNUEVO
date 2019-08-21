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
    public class Paciente_Paciente_AsociadoController : Controller
    {
        private EMEPEntities db = new EMEPEntities();
        public static List<Paciente_Paciente_Asociado> listaAsociado = new List<Paciente_Paciente_Asociado>();
        // GET: Paciente_Paciente_Asociado

     public Paciente_Paciente_AsociadoController()
        {
            Paciente_Paciente_Asociado.listaDatos1 = new List<Datos_Paciente>();
            Paciente_Paciente_Asociado.listaPaciente1 = new List<Paciente>();
        }

        public ActionResult Index()
        {
            var paciente_Paciente_Asociado = db.Paciente_Paciente_Asociado.Include(p => p.Datos_Paciente).Include(p => p.Paciente);
            return View(paciente_Paciente_Asociado.ToList());
        }

      

      

        public ActionResult IndexPaciente()
        {
            //List<Datos_Paciente> listaDa = new List<Datos_Paciente>();
            foreach (var item in Datos_PacienteController.listaDatos)
            {
                Paciente_Paciente_Asociado.listaDatos1.Add(item);
            }

            foreach (var item in PacienteController.listaPaciente)
            {
                Paciente_Paciente_Asociado.listaPaciente1.Add(item);
            }

            ViewBag.Paciente= Paciente_Paciente_Asociado.listaDatos1;
            ViewBag.Datos = Paciente_Paciente_Asociado.listaPaciente1;

            return View();
        }

     /*   public ActionResult IndexPaciente()
        {
            List<Datos_Paciente> listaDap = new List<Datos_Paciente>();
            foreach (var item in Datos_PacienteController.listaDatos)
            {
                listaDap.Add(item);
            }
            return View();
        }*/

        // GET: Paciente_Paciente_Asociado/Details/5
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

        // GET: Paciente_Paciente_Asociado/Create
        public ActionResult Create()
        {
            ViewBag.ID_PACIENTE_ASOCIADO = new SelectList(db.Datos_Paciente, "id", "tipo_sangre");
            ViewBag.ID_PACIENTE = new SelectList(db.Paciente, "correo", "cedula");
            return View();
        }

        // POST: Paciente_Paciente_Asociado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente_Paciente_Asociado paciente_Paciente_Asociado)
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

        // GET: Paciente_Paciente_Asociado/Edit/5
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

        // POST: Paciente_Paciente_Asociado/Edit/5
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

        // GET: Paciente_Paciente_Asociado/Delete/5
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

        // POST: Paciente_Paciente_Asociado/Delete/5
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
