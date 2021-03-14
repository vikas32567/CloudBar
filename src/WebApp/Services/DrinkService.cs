using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Context;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IDapperDrinkRepo dapperDrinkRepo;
        private readonly IEfDrinkRepo efDrinkRepo;

        public DrinkService(IDapperDrinkRepo dapperDrinkRepo, IEfDrinkRepo efDrinkRepo)
        {
            this.dapperDrinkRepo = dapperDrinkRepo;
            this.efDrinkRepo = efDrinkRepo;
        }

        public List<Drink> GetDrinksByDapper() => dapperDrinkRepo.GetDrinks();
        public List<Drink> GetDrinksByEf() => efDrinkRepo.GetDrinks();

        public async Task<Drink> AddDrink(Drink drink) => await efDrinkRepo.AddDrink(drink);

        public async Task<Drink> UpdateDrink(Drink drink) => await efDrinkRepo.UpdateDrink(drink);

        public async Task<bool> DeleteDrink(long id) => await efDrinkRepo.DeleteDrink(id);
    }
}