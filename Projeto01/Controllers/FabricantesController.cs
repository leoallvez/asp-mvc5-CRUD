using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto01.Contexts;
using Projeto01.Models;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace Projeto01.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            context.Fabricantes.Add(fabricante);
            context.SaveChanges();
            TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi criado";
            return RedirectToAction("Index");

        }

        //GET: Fabricante/Edit/5
        //long? id possibilita valores nulos
        public ActionResult Edit(long? id)
        {
            if( id == null)
             {
                // Retornando um Erro.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
            // Buscando fabricante.
            Fabricante fabricante = context.Fabricantes.Find(id);

            if(fabricante == null)
            {
                //HTTP 404.	
                return HttpNotFound();
            }

            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            /** 
             * Verificar se o estado do model é válido, como por exemplo
             * se um campo obrigatório foi preenchido.
             */
            if(ModelState.IsValid)
            {
                context.Entry(fabricante).State = EntityState.Modified;
                context.SaveChanges();
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi alterado";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest);
            }

            //Fabricante fabricante = context.Fabricantes.Where(f => f.FabricanteId == id).Include("Produto.Categoria").First();
            Fabricante fabricante = context.Fabricantes.Where(f => f.FabricanteId == id).Include("Produtos.Categoria").First();

            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        public ActionResult Delete(long? id)
        {
            if( id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fabricante fabricante = context.Fabricantes.Find(id);

            if(fabricante == null)
            {
                return HttpNotFound();
            }

            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            //O	TempData armazena um valor em uma curta sessão de tempo.
            TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}