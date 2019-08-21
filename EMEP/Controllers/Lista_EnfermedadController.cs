using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMEP.Models;
using System.IO;

namespace EMEP.Controllers
{
    public class Lista_EnfermedadController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        // GET: Lista_Enfermedad
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var lista_Enfermedad = db.Lista_Enfermedad.Include(l => l.Categoria);
            foreach (var lista in lista_Enfermedad)
            {
                if (lista.estado == 1)
                {

                    lista.estado_String = "Activo";
                }
                if (lista.estado == 2)
                {
                    lista.estado_String = "Inactivo";
                }

            }
            return View(lista_Enfermedad.ToList());
        }

        // GET: Lista_Enfermedad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la Enfermedad.";
                return RedirectToAction("Index");
            }
            Lista_Enfermedad lista = db.Lista_Enfermedad.Find(id);

            if (lista.estado == 1)
            {

                lista.estado_String = "Activo";
            }
            if (lista.estado == 2)
            {
                lista.estado_String = "Inactivo";
            }


            if (lista == null)
            {
                TempData["mensaje"] = "La Enfermedad no éxiste.";
                return RedirectToAction("Index");
            }
            return View(lista);
        }

        // GET: Lista_Enfermedad/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORIA = new SelectList(db.Categoria, "id", "descripcion");
            return View();
        }

        // POST: Lista_Enfermedad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lista_Enfermedad lista_Enfermedad, HttpPostedFileBase ImageData)
        {
            if (ImageData != null && ImageData.ContentLength > 0)
            {
                byte[] imagenData = null;
                using (var binaryImagen = new BinaryReader(ImageData.InputStream))
                {
                    imagenData = binaryImagen.ReadBytes(ImageData.ContentLength);
                }
                lista_Enfermedad.img = imagenData;
            }
            try
            {
                lista_Enfermedad.estado = 1;
                db.Lista_Enfermedad.Add(lista_Enfermedad);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ID_CATEGORIA = new SelectList(db.Categoria, "id", "descripcion", lista_Enfermedad.ID_CATEGORIA);
                return View(lista_Enfermedad);
            }
        }

        // GET: Lista_Enfermedad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la Enfermedad.";
                return RedirectToAction("Index");
            }
            Lista_Enfermedad lista_Enfermedad = db.Lista_Enfermedad.Find(id);
            if (lista_Enfermedad.estado == 1)
            {
                lista_Enfermedad.estado_String = "Activo";

            }
            else
            {
                lista_Enfermedad.estado_String = "Inactivo";
            }

            if (lista_Enfermedad == null)
            {
                TempData["mensaje"] = "La Enfermedad no éxiste.";
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.Categoria, "id", "descripcion", lista_Enfermedad.ID_CATEGORIA);
            return View(lista_Enfermedad);
        }

        // POST: Lista_Enfermedad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lista_Enfermedad lista_Enfermedad)
        {
            try
            {
                db.Entry(lista_Enfermedad).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Actualizado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ID_CATEGORIA = new SelectList(db.Categoria, "id", "descripcion", lista_Enfermedad.ID_CATEGORIA);
                return View(lista_Enfermedad);
            }

        }

        // GET: Lista_Enfermedad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la Enfermedad.";
                return RedirectToAction("Index");
            }
            Lista_Enfermedad lista_Enfermedad = db.Lista_Enfermedad.Find(id);
            if (lista_Enfermedad.estado == 1)
            {
                lista_Enfermedad.estado_String = "Activo";

            }
            else
            {
                lista_Enfermedad.estado_String = "Inactivo";
            }
            if (lista_Enfermedad == null)
            {
                TempData["mensaje"] = "La Enfermedad no éxiste.";
                return RedirectToAction("Index");
            }
            return View(lista_Enfermedad);
        }

        // POST: Lista_Enfermedad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lista_Enfermedad lista_Enfermedad = db.Lista_Enfermedad.Find(id);
            if (lista_Enfermedad.estado == 1)
            {
                lista_Enfermedad.estado = 0;

            }
            else
            {
                lista_Enfermedad.estado = 1;
            }
            db.SaveChanges();
            TempData["mensaje"] = "Estado Actualizado.";
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
