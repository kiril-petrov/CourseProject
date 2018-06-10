using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using System.Web;

namespace RecipeCourseProject.Models
{

    public class RecipesViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ChefID { get; set; }
        public Chef Chef { get; set; }
        public string Description { get; set; }
        public List<IngredientLink> Ingredients { get; set; }

        public RecipesViewModel(Recipe recipe)
        {
            this.ID = recipe.ID;
            this.Name = recipe.Name;
            this.ChefID = recipe.ChefID;
            this.Chef = recipe.Chef;
            this.Description = recipe.Description;
            this.Ingredients = recipe.Ingredients.ToList();
        }

    }

    public class RecipeViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int ChefID { get; set; }
        public Chef Chef { get; set; }
        public string Description { get; set; }
        public List<IngredientLink> Ingredients { get; set; }
        public List<RecipesViewModel> recipesList;
        public List<int> IngredientIds { get; set; }


        public RecipeViewModel()
        {
            recipesList = new List<RecipesViewModel>();
        }

        public RecipeViewModel(Recipe recipe)
        {
            this.ID = recipe.ID;
            this.Name = recipe.Name;
            this.ChefID = recipe.ChefID;
            this.Chef = recipe.Chef;
            this.Description = recipe.Description;
            this.Ingredients = recipe.Ingredients.ToList();
        }

        public RecipeViewModel(List<Recipe> list)
            : this()
        {
            foreach (Recipe recipe in list)
            {
                recipesList.Add(new RecipesViewModel(recipe));
            }
        }

    }
}