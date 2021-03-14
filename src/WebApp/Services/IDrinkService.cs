using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Context;

namespace WebApp.Services
{
    public interface IDrinkService
    {
        List<Drink> GetDrinksByDapper();
        List<Drink> GetDrinksByEf();
        
        Task<Drink> AddDrink(Drink drink);
        Task<Drink> UpdateDrink(Drink drink);
        Task<bool> DeleteDrink(long id);
    }
}