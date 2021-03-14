using WebApp.Context;

namespace WebApp.ViewModels
{
    public class IngredientViewModel
    {
        public long SpiritId { get; set; }
        public int Percentage { get; set; }

        public Ingredient ToIngredient()
        {
            var ingredient = new Ingredient();

            ingredient.SpiritId = SpiritId;
            ingredient.Percentage = Percentage;

            return ingredient;
        }

        public IngredientViewModel()
        {
            
        }

        public IngredientViewModel(Ingredient ingredient)
        {
            SpiritId = ingredient.SpiritId;
            Percentage = ingredient.Percentage;
        }
    }
}