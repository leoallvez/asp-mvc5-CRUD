using System;
using System.Collections.Generic;
using Projeto01.Models;
using System.Linq; //Obriga

using System.Web;
using System.Web.Mvc;

namespace Projeto01.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria() {
                CategoriaId = 1,
                Nome = "Nomebooks"
            },
            new Categoria()
            {
                CategoriaId = 2,
                Nome = "Monitores"
            },
            new Categoria()
            {
                CategoriaId = 3,
                Nome = "Impressoras"
            },
            new Categoria()
            {
                CategoriaId = 4,
                Nome = "Mouse"
            },
            new Categoria()
            {
                CategoriaId = 5,
                Nome = "Desktops"
            }
        };
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias.OrderBy(c => c.Nome));
            //return View(categorias);
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
            categorias.Add(categoria);
            /**LINQ*/
            categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            //Voltar para a Index do CRUD.
            return RedirectToAction("Index");

        }
        /**recuperando	o	primeiro	objeto	que
        tenha na  propriedade CategoriaId*/
        //GET: Post
        public ActionResult Edit(long id)
        {
            return View(categorias.Where( m => m.CategoriaId == id).First());
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
            categorias.Remove(categorias.Where(
                            c => c.CategoriaId == categoria.CategoriaId)
                            .First());
            return RedirectToAction("Index");
        }


    }
}