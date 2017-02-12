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
    public class GruposController : Controller
    {
        private ProyectoCompraContext db = new ProyectoCompraContext();

        // GET: /Grupos/
        public ActionResult Index()
        {
            return View(db.Grupoes.ToList());
        }

        // GET: /Grupos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupoes.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // GET: /Grupos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Grupos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GrupoID,descripcion")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Grupoes.Add(grupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupo);
        }

        // GET: /Grupos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupoes.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // POST: /Grupos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GrupoID,descripcion")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupo);
        }

        // GET: /Grupos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupoes.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // POST: /Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupo grupo = db.Grupoes.Find(id);
            db.Grupoes.Remove(grupo);
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
