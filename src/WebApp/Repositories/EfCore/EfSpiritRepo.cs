using System.Collections.Generic;
using System.Linq;
using WebApp.Context;

namespace WebApp.Repositories
{
    public class EfSpiritRepo : IEfSpiritRepo
    {
        private readonly CloudBarEfContext efContext;

        public EfSpiritRepo(CloudBarEfContext efContext)
        {
            this.efContext = efContext;
        }

        public List<Spirit> GetSpirits()
        {
            return efContext.Spirits.ToList();
        }
    }
}