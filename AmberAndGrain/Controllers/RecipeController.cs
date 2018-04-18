using AmberAndGrain.Models;
using AmberAndGrain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmberAndGrain.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            var repo = new RecipeRepository();
            var recipes = repo.GetAll();
            
            return View(recipes);
        }

        // Get: Recipe/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Post: Recipe/create
        [HttpPost]
        public ActionResult Create(RecipeDto recipe)
        {
            var repo = new RecipeRepository();
            repo.Create(recipe);
            //Save it to the database
            return RedirectToAction("index");
        }

        // Get: recipe/edit/1
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var repo = new RecipeRepository();
            RecipeDto recipe = repo.Get(id);

            if (recipe == null)
            {
                return HttpNotFound("The recipe you requested does not exist");
            }
            return View(recipe);
        }

        [HttpPost]
        public ActionResult Edit(int id, RecipeDto recipe)
        {
            if (!ModelState.IsValid)
            {
                return View(recipe);
            }

            var repo = new RecipeRepository();
            repo.Update(id, recipe);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var repo = new RecipeRepository();
            var recipe = repo.Get(id);

            return View(recipe);
        }
    }
}