using System.Collections.Generic;
using WebApp.Context;

namespace WebApp.Repositories
{
    public interface IDapperDrinkRepo
    {
        List<Drink> GetDrinks();
    }
}