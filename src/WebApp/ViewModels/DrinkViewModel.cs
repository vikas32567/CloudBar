using System.Collections.Generic;
using WebApp.Context;

namespace WebApp.ViewModels
{
    public class DrinkViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal OverheadCost { get; set; }

        public List<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();
        public List<Spirit> AllSpirits { get; set; }

        public DrinkViewModel()
        {
            
        }

        public DrinkViewModel(Drink drink)
        {
            Id = drink.Id;
            Name = drink.Name;
            Description = drink.Description;
            Quantity = drink.Quantity;
            OverheadCost = drink.OverheadCost;

            foreach (var ingredient in drink.Ingredients)
            {
                Ingredients.Add(new IngredientViewModel(ingredient));
            }
        }

        public Drink ToDrink()
        {
            var drink = new Drink();
            
            drink.Name = Name;
            drink.Description = Description;
            drink.Quantity = Quantity;
            drink.OverheadCost = OverheadCost;

            foreach (var ingredient in Ingredients)
            {
                drink.Ingredients.Add(ingredient.ToIngredient());
            }

            return drink;
        }
    }

}