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
    public class IngredientController : Controller
    {
        IngredientRepository repo = new IngredientRepository();

        // GET: Chef
        public ActionResult Index()
        {

            IngredientViewModel model = new IngredientViewModel(repo.GetAll());

            return View(model);
        }

        public ActionResult View(int id)
        {
            IngredientViewModel model = new IngredientViewModel(repo.GetByID(id));

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            IngredientViewModel model = new IngredientViewModel();

            if (id != 0)
            {
                model = new IngredientViewModel(repo.GetByID(id));
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(IngredientViewModel model)
        {
            Ingredient ingredient = repo.GetByID(model.ID);

            if (model.ID == 0)
            {
                ingredient = new Ingredient();
            }

            ingredient.Name = model.Name;

            repo.Save(ingredient);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repo.DeleteByID(id);

            return RedirectToAction("Index");
        }
    }
}