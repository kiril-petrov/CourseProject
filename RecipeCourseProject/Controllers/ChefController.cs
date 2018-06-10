using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Repositories;
using RecipeCourseProject.Models;

namespace RecipeCourseProject.Controllers
{
    public class ChefController : Controller
    {

        ChefRepository repo = new ChefRepository();

        // GET: Chef
        public ActionResult Index()
        {

            ChefViewModel model = new ChefViewModel(repo.GetAll());

            return View(model);
        }

        public ActionResult View(int id)
        {
            ChefViewModel model = new ChefViewModel(repo.GetByID(id));

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ChefViewModel model = new ChefViewModel();

            if (id != 0)
            {
                model = new ChefViewModel(repo.GetByID(id));
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ChefViewModel model)
        {
            Chef chef = repo.GetByID(model.ID);

            if (model.ID == 0)
            {
                chef = new Chef();
            }

            chef.Name = model.Name;

            repo.Save(chef);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repo.DeleteByID(id);

            return RedirectToAction("Index");
        }
    }
}