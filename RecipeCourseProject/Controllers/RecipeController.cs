using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeCourseProject.Models;
using DataAccess;
using Repositories;

namespace RecipeCourseProject.Controllers
{
    public class RecipeController : Controller
    {

        RecipeRepository repo = new RecipeRepository();

        // GET: Recipe
        public ActionResult Index()
        {
            RecipeViewModel model = new RecipeViewModel(repo.GetAll());

            return View(model);
        }

        public ActionResult View(int id)
        {
            RecipeViewModel model = new RecipeViewModel(repo.GetByID(id));
            IngredientRepository ingredientRepository = new IngredientRepository();

            List<Ingredient> ingredients = new List<Ingredient>();

            foreach (IngredientLink link in model.Ingredients)
            {
                ingredients.Add(ingredientRepository.GetByID(link.IngredientID));
            }

            ViewBag.Ingredients = ingredients;

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            RecipeViewModel model = new RecipeViewModel();

            if (id != 0)
            {
                model = new RecipeViewModel(repo.GetByID(id));
            }

            ChefRepository chefRepo = new ChefRepository();
            SelectList chefList = new SelectList(chefRepo.GetAll(), "ID", "Name");
            ViewBag.chefList = chefList;

            IngredientRepository ingredientRepo = new IngredientRepository();
            SelectList ingredientList = new SelectList(ingredientRepo.GetAll(), "ID", "Name");
            ViewBag.ingredientList = ingredientList;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RecipeViewModel model)
        {

            List<IngredientLink> ingredients = new List<IngredientLink>();
            IngredientLinkRepository ingredientLinkRepository = new IngredientLinkRepository();
            ChefRepository chefRepository = new ChefRepository();

            foreach (int id in model.IngredientIds)
            {
                ingredients.Add(new IngredientLink
                {
                    RecipeID = model.ID,
                    IngredientID = id
                });
            }

            Recipe recipe = repo.GetByID(model.ID);

            if (model.ID == 0)
            {
                recipe = new Recipe();
                recipe.ID = 0;
            }


            recipe.Name = model.Name;
            recipe.ChefID = model.ChefID;
            recipe.Description = model.Description;
            recipe.Ingredients = ingredients;

            repo.Save(recipe);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repo.DeleteByID(id);
            return RedirectToAction("Index");
        }
    }
}