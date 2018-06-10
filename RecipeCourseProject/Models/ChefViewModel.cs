using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using System.Web;

namespace RecipeCourseProject.Models
{

    public class ChefsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }

        public ChefsViewModel(Chef chef)
        {
            this.ID = chef.ID;
            this.Name = chef.Name;
            this.Recipes = chef.Recipes.ToList();
        }

    }

    public class ChefViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<ChefsViewModel> chefsList;

        public ChefViewModel()
        {
            this.chefsList = new List<ChefsViewModel>();
        }

        public ChefViewModel(Chef chef)
        {
            this.ID = chef.ID;
            this.Name = chef.Name;
            this.Recipes = chef.Recipes.ToList();
        }

        public ChefViewModel(List<Chef> list)
            : this()
        {
            foreach (Chef chef in list)
            {
                chefsList.Add(new ChefsViewModel(chef));
            }
        }

    }
}