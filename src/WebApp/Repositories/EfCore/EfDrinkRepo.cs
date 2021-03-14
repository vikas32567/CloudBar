using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;

namespace WebApp.Repositories
{
    public class EfDrinkRepo : IEfDrinkRepo
    {
        private readonly CloudBarEfContext efContext;

        public EfDrinkRepo(CloudBarEfContext efContext)
        {
            this.efContext = efContext;
        }

        public List<Drink> GetDrinks()
        {
            return efContext.Drinks.Include(d => d.Ingredients).ToList();
        }

        public async Task<Drink> AddDrink(Drink drink)
        {
            efContext.Drinks.Add(drink);
            await efContext.SaveChangesAsync();

            return drink;
        }

        public async Task<Drink> UpdateDrink(Drink drink)
        {
            efContext.Drinks.Update(drink);
            await efContext.SaveChangesAsync();

            return drink;
        }

        public async Task<bool> DeleteDrink(long id)
        {
            var drink = efContext.Drinks.Where(d => d.Id == id).FirstOrDefault();
            efContext.Drinks.Remove(drink);
            await efContext.SaveChangesAsync();

            return true;
        }
    }
}