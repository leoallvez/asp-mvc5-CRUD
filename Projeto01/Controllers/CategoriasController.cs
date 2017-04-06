using System;
using System.Collections.Generic;
using Projeto01.Models;
using System.Linq; //Obriga

using Projeto01.Contexts;
using Projeto01.Models;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace Projeto01.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Categorias
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }
        //GET: Create
        public ActionResult Create()
        {
            return View();
        }
        //GET: Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        /**recuperando	o	primeiro	objeto	que
        tenha na  propriedade CategoriaId*/
        //GET: Post
        public ActionResult Edit(long id)
        {


            if (id == null)
            {
                // Retornando um Erro.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Buscando fabricante.
            Fabricante categoria = context.Categorias.Find(id);

            if (fabricante == null)
            {
                //HTTP 404.	
                return HttpNotFound();
            }

            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            return RedirectToAction("Index");
        }




    }
}