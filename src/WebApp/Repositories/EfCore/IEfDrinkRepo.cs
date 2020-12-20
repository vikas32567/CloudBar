using System.Collections.Generic;
using WebApp.Context;

namespace WebApp.Repositories
{
    public interface IEfDrinkRepo
    {
        List<Drink> GetDrinks();
    }
}