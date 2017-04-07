using System;
using System.Collections.Generic;
using Projeto01.Models;
using System.Linq; 
using Projeto01.Contexts;
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
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                // Retornando um Erro.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Buscando categoria.
            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
            {
                //HTTP 404.	
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            /** 
             * Verificar se o estado do model é válido, como por exemplo
             * se um campo obrigatório foi preenchido.
             */
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
            }
            return View(categoria);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {

            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}