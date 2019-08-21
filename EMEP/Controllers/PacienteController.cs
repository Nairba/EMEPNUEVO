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
    public class PacienteController : Controller
    {
        private EMEPEntities db = new EMEPEntities();
        public static List<Paciente> listaPaciente = new List<Paciente>();

        // GET: Paciente
        public ActionResult Index()
        {
            var paciente = db.Paciente.Include(p => p.Tipo_Usuario);
            return View(paciente.ToList());
        }

        public ActionResult IndexPa()
        {

            string correoSesion = Session["CorreoId"].ToString();
            var pacientes = from m in db.Paciente
                          where m.correo == correoSesion
                          select m;

            foreach (var paciente in pacientes)
            {
                if (paciente.correo.Equals(correoSesion))
                {
                    if (paciente.estado == 1)
                    {

                        paciente.estado_String = "Activo";
                    }
                    if (paciente.estado == 2)
                    {
                        paciente.estado_String = "Inactivo";
                    }
                }
                pacientes.Include(paciente.ToString());
            }
            return View(pacientes.ToList());
        }


        // GET: Paciente/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

      
        // GET: Paciente/Create
        public ActionResult Create()
        {
            ViewBag.listaTipo = new SelectList(db.Tipo_Usuario, "id", "descripcion");
            return View();
        }

        // POST: Paciente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Paciente paciente)
        {
            if (ModelState.IsValid)
            {

                listaPaciente.Add(paciente);
                db.Paciente.Add(paciente);
              
                db.SaveChanges();
                return RedirectToAction("Create");
                
            }

            ViewBag.listaTipo = new SelectList(db.Tipo_Usuario, "id", "descripcion", paciente.ID_TIPO_USUARIO);
            return View(paciente);
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.listaTipo = new SelectList(db.Tipo_Usuario, "id", "descripcion", paciente.ID_TIPO_USUARIO);
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.listaTipo = new SelectList(db.Tipo_Usuario, "id", "descripcion", paciente.ID_TIPO_USUARIO);
            return View(paciente);
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Paciente paciente = db.Paciente.Find(id);
            db.Paciente.Remove(paciente);
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
