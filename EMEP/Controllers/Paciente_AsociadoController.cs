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
            List<SelectListItem> sexolist = new List<SelectListItem>();
            sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "1" });
            sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "2" });
            sexolist.Add(new SelectListItem() { Text = "Complicado", Value = "3" });
            ViewBag.Opcion = sexolist;

            List<SelectListItem> estadoList = new List<SelectListItem>();
            estadoList.Add(new SelectListItem() { Text = "Inactivo", Value = "0" });
            estadoList.Add(new SelectListItem() { Text = "Activo", Value = "1" });
            ViewBag.Opcion2 = estadoList;

            List<SelectListItem> tipoSangreList = new List<SelectListItem>();
            tipoSangreList.Add(new SelectListItem() { Text = "O-", Value = "1" });
            tipoSangreList.Add(new SelectListItem() { Text = "O+", Value = "2" });
            tipoSangreList.Add(new SelectListItem() { Text = "A-", Value = "3" });
            tipoSangreList.Add(new SelectListItem() { Text = "A+", Value = "4" });
            tipoSangreList.Add(new SelectListItem() { Text = "B-", Value = "5" });
            tipoSangreList.Add(new SelectListItem() { Text = "B+", Value = "6" });
            tipoSangreList.Add(new SelectListItem() { Text = "AB-", Value = "7" });
            tipoSangreList.Add(new SelectListItem() { Text = "AB+", Value = "8" });
            tipoSangreList.Add(new SelectListItem() { Text = "Sin definir", Value = "9" });
            ViewBag.Opcion3 = tipoSangreList;

            List<SelectListItem> parentescoList = new List<SelectListItem>();

            parentescoList.Add(new SelectListItem() { Text = "Padre", Value = "1" });
            parentescoList.Add(new SelectListItem() { Text = "Madre", Value = "2" });
            parentescoList.Add(new SelectListItem() { Text = "Hermano", Value = "3" });
            parentescoList.Add(new SelectListItem() { Text = "Hermana", Value = "4" });
            parentescoList.Add(new SelectListItem() { Text = "Hijo", Value = "5" });
            parentescoList.Add(new SelectListItem() { Text = "Hija", Value = "6" });
            parentescoList.Add(new SelectListItem() { Text = "Esposa", Value = "7" });
            parentescoList.Add(new SelectListItem() { Text = "Esposo", Value = "8" });
            ViewBag.Opcion4 = parentescoList;

            return View();
        }

        // POST: Paciente_Asociado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente_Asociado paciente_Asociado)
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }

            try
            {
                paciente_Asociado.estado = 1;
                paciente_Asociado.Tipo_Usuario.id = 4;
                db.Paciente_Asociado.Add(paciente_Asociado);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito.";
                return RedirectToAction("Index");
            }
            catch 
            {
            
                return View(paciente_Asociado);
            }
           
        }

        // GET: Paciente_Asociado/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {

                TempData["mensaje"] = "Especifique la Administrador.";
                return RedirectToAction("Index");
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
