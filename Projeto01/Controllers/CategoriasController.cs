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
            return View(categorias);
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

    }
}