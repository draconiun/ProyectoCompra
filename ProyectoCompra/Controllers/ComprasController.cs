using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoCompra.Models;
using System.Data.Entity.Core.Objects;

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

        public JsonResult ListarLibro(int LibroID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var libros = (from p in db.Libroes select p).ToList();
                    Libro objLibro = new Libro();
                    foreach (Libro libro in libros)
                    {
                        Libro oLibro = new Libro();
                        oLibro.LibroID = libro.LibroID;
                        oLibro.nombre = libro.nombre;
                        oLibro.precio = libro.precio;
                        oLibro.stock = libro.stock;
                        oLibro.CategoriaID = libro.CategoriaID;
                        if (oLibro.LibroID == LibroID) objLibro = oLibro;
                    }
                    return Json(new { Success = 1, resultado = objLibro, ex = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se pudo Crear Este Registro").Message.ToString() }); 
        }

        public JsonResult ListarCategoriaById(int CategoriaID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var libros = db.Libroes.Where(x => x.Categoria.CategoriaID == CategoriaID);
                    //int cantidadLista = libros.ToList().Count;
                    var datos = (from p in db.Libroes select p).ToList();
                    List<Libro> oListLibros = new List<Libro>();
                    foreach (Libro libro in datos)
                    {
                        Libro oLibro = new Libro();
                        oLibro.LibroID = libro.LibroID;
                        oLibro.nombre = libro.nombre;
                        oLibro.CategoriaID = libro.CategoriaID;
                        if(oLibro.CategoriaID==CategoriaID) oListLibros.Add(oLibro);
                    }

                    return Json(new { Success = 1, resultado = oListLibros, ex = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se pudo Crear Este Registro").Message.ToString() }); 
        }

        public ActionResult Nuevo()
        {
            //ViewBag.LibroID = new SelectList(db.Libroes, "LibroID", "nombre");
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "nombre");
            return View();
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo([Bind(Include = "CompraID,PersonaID,LibroID,cantidad")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                compra.PersonaID = 1;
                db.Compras.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LibroID = new SelectList(db.Libroes, "LibroID", "nombre", compra.LibroID);
            return View(compra);
        }*/

        public JsonResult Nuevo_Registro(string cadena,string cantidades)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    String[] libros = cadena.Split(' ');
                    String[] cantidad_libro = cantidades.Split(' ');

                    Grupo oGrupo=new Grupo();
                    oGrupo.descripcion ="Nuevo Grupo";
                    db.Grupoes.Add(oGrupo);
                    db.SaveChanges();
                    int id = oGrupo.GrupoID;
                    for (int i = 0; i < libros.Length-1;i++ )
                    {
                        Compra oCompra = new Compra();
                        oCompra.PersonaID = 1;
                        oCompra.LibroID = int.Parse( libros[i].ToString()) ;
                        oCompra.GrupoID = id;
                        oCompra.cantidad = int.Parse(cantidad_libro[i].ToString());
                        db.Compras.Add(oCompra);
                        db.SaveChanges();
                    }
                    return Json(new { Success = 1, resultado = "", ex = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se pudo Crear Este Registro").Message.ToString() }); 
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
        public ActionResult Create([Bind(Include="CompraID,PersonaID,LibroID,cantidad")] Compra compra)
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
        public ActionResult Edit([Bind(Include="CompraID,PersonaID,LibroID,cantidad")] Compra compra)
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
