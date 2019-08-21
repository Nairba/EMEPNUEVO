﻿using EMEP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EMEP.Controllers
{
    public class Tipo_UsuarioController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        // GET: Tipo_Usuario
        public ActionResult Index()
        {
            return View(db.Tipo_Usuario.ToList());
        }

        // GET: Tipo_Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Usuario tipo_Usuario = db.Tipo_Usuario.Find(id);
            if (tipo_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Usuario);
        }

        // GET: Tipo_Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipo_Usuario tipo_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Usuario.Add(tipo_Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Usuario);
        }

        // GET: Tipo_Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Usuario tipo_Usuario = db.Tipo_Usuario.Find(id);
            if (tipo_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Usuario);
        }

        // POST: Tipo_Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion")] Tipo_Usuario tipo_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Usuario);
        }

        // GET: Tipo_Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Usuario tipo_Usuario = db.Tipo_Usuario.Find(id);
            if (tipo_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Usuario);
        }

        // POST: Tipo_Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Usuario tipo_Usuario = db.Tipo_Usuario.Find(id);
            db.Tipo_Usuario.Remove(tipo_Usuario);
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
