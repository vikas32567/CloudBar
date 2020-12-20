using System.Collections.Generic;
using System.Linq;
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
            return efContext.Drinks.ToList();
        }
    }
}