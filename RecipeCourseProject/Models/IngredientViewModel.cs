using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace RecipeCourseProject.Models
{

    public class IngredientsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<IngredientLink> Recipes;

        public IngredientsViewModel(Ingredient ingredient)
        {
            this.ID = ingredient.ID;
            this.Name = ingredient.Name;
            this.Recipes = ingredient.Recipes.ToList();
        }
    }

    public class IngredientViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public List<IngredientLink> Recipes;
        public List<IngredientsViewModel> ingredientList;

        public IngredientViewModel()
        {
            this.ingredientList = new List<IngredientsViewModel>();
        }

        public IngredientViewModel(Ingredient ingredient)
        {
            this.ID = ingredient.ID;
            this.Name = ingredient.Name;
            this.Recipes = ingredient.Recipes.ToList();
        }

        public IngredientViewModel(List<Ingredient> list)
            : this()
        {
            foreach (Ingredient ingredient in list)
            {
                ingredientList.Add(new IngredientsViewModel(ingredient));
            }
        }
    }
}