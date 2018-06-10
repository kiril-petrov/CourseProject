using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace RecipeCourseProject.Models
{
    public class LinksViewModel
    {
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }

        public LinksViewModel(IngredientLink link)
        {
            RecipeID = link.RecipeID;
            IngredientID = link.IngredientID;
            Amount = link.Amount;
            Recipe = link.Recipe;
            Ingredient = link.Ingredient;
        }

    }

    public class LinkViewModel
    {

        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public string Amount { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }

        public List<LinksViewModel> linkList;

        public LinkViewModel()
        {
            linkList = new List<LinksViewModel>();
        }

        public LinkViewModel(IngredientLink link)
        {
            RecipeID = link.RecipeID;
            IngredientID = link.IngredientID;
            Amount = link.Amount;
            Recipe = link.Recipe;
            Ingredient = link.Ingredient;
        }
        
        public LinkViewModel(List<IngredientLink> list)
            : this()
        {
            foreach (IngredientLink link in list)
            {
                linkList.Add(new LinksViewModel(link));
            }
        }

    }
}