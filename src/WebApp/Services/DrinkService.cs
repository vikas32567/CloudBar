using System.Collections.Generic;
using WebApp.Context;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class DrinkService
    {
        private readonly IDapperDrinkRepo dapperDrinkRepo;

        public DrinkService(IDapperDrinkRepo dapperDrinkRepo)
        {
            this.dapperDrinkRepo = dapperDrinkRepo;
        }

        public List<Drink> GetDrinksByDapper()
        {
            return dapperDrinkRepo.GetDrinks();
        }
    }
}