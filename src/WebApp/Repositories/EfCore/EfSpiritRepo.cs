using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Spirit GetSpirit(long spiritId)
        {
            return efContext.Spirits.Where(s => s.Id == spiritId).FirstOrDefault();
        }

        public async Task<Spirit> AddSpirit(Spirit spirit)
        {
            var spiritAlreadyExists = efContext.Spirits.Where(s => s.Name == spirit.Name).Any();

            if (spiritAlreadyExists)
                return null;

            efContext.Spirits.Add(spirit);
            await efContext.SaveChangesAsync();

            return spirit;
        }

        public async Task<Spirit> UpdateSpirit(Spirit newSpirit)
        {
            efContext.Spirits.Update(newSpirit);
            await efContext.SaveChangesAsync();

            return newSpirit;
        }
    }
}