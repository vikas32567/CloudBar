using WebApp.ViewModels;
using WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace WebApp.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrinkService drinkService;
        private readonly ISpiritService spiritService;

        public DrinkController(IDrinkService drinkService, ISpiritService spiritService)
        {
            this.drinkService = drinkService;
            this.spiritService = spiritService;
        }

        [HttpGet("drinks")]
        public IActionResult GetDrinks()
        {
            var drinks = drinkService.GetDrinksByEf().Select(d => new DrinkViewModel(d)).ToList();
            return View("Index", drinks);
        }
        
        [HttpGet("drinks/add")]
        public IActionResult AddDrink() 
        {
            var drinkViewModel = new DrinkViewModel();
            drinkViewModel.AllSpirits = spiritService.GetSpiritsByDapper();
            
            for(int i = 0; i < 4; i++)
            {
                drinkViewModel.Ingredients.Add(new IngredientViewModel());
            }

            return View(drinkViewModel);
        }

        [HttpPost("drinks/add")]
        public async Task<IActionResult> AddDrink([FromForm] DrinkViewModel newDrink) 
        {
            // if (!ModelState.IsValid)
            //     return View (newDrink);

            newDrink.Ingredients.RemoveAll(i => i.SpiritId <= 0);
            await drinkService.AddDrink(newDrink.ToDrink());

            return View(newDrink);
        }

        
    }
}