using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Context;

namespace WebApp.Repositories
{
    public interface IEfDrinkRepo
    {
        List<Drink> GetDrinks();

        Task<Drink> AddDrink(Drink drink);
        Task<Drink> UpdateDrink(Drink drink);
        Task<bool> DeleteDrink(long id);
    }
}