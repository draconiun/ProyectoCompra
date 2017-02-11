using System;
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
    public class ComprasController : Controller
    {
        private ProyectoCompraContext db = new ProyectoCompraContext();

        // GET: /Compras/
        public ActionResult Index()
        {
            var compras = db.Compras.Include(c => c.Libro).Include(c => c.Persona);
            return View(compras.ToList());
        }

        // GET: /Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: /Compras/Create
        public ActionResult Create()
        {
            ViewBag.LibroID = new SelectList(db.Libroes, "LibroID", "nombre");
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "apellidoPaterno");
            return View();
        }

        // POST: /Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CompraID,PersonaID,LibroID")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compras.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LibroID = new SelectList(db.Libroes, "LibroID", "nombre", compra.LibroID);
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "apellidoPaterno", compra.PersonaID);
            return View(compra);
        }

        // GET: /Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.LibroID = new SelectList(db.Libroes, "LibroID", "nombre", compra.LibroID);
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "apellidoPaterno", compra.PersonaID);
            return View(compra);
        }

        // POST: /Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CompraID,PersonaID,LibroID")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LibroID = new SelectList(db.Libroes, "LibroID", "nombre", compra.LibroID);
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "apellidoPaterno", compra.PersonaID);
            return View(compra);
        }

        // GET: /Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: /Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compras.Find(id);
            db.Compras.Remove(compra);
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
