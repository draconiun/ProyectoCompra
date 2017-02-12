﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoCompra.Models;

namespace ProyectoCompra.Controllers
{
    public class LibrosController : Controller
    {
        private ProyectoCompraContext db = new ProyectoCompraContext();

        // GET: /Libros/
        public ActionResult Index()
        {
            var libroes = db.Libroes.Include(l => l.Categoria);
            return View(libroes.ToList());
        }

        // GET: /Libros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libroes.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: /Libros/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "nombre");
            return View();
        }

        // POST: /Libros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LibroID,nombre,stock,precio,CategoriaID")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Libroes.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "nombre", libro.CategoriaID);
            return View(libro);
        }

        // GET: /Libros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libroes.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "nombre", libro.CategoriaID);
            return View(libro);
        }

        // POST: /Libros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="LibroID,nombre,stock,precio,CategoriaID")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "nombre", libro.CategoriaID);
            return View(libro);
        }

        // GET: /Libros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libroes.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: /Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro libro = db.Libroes.Find(id);
            db.Libroes.Remove(libro);
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
