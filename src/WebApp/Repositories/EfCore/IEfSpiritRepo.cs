using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Context;

namespace WebApp.Repositories
{
    public interface IEfSpiritRepo
    {
        List<Spirit> GetSpirits();
        Spirit GetSpirit(long spiritId);
        Task<Spirit> AddSpirit(Spirit spirit);
        Task<Spirit> UpdateSpirit(Spirit newSpirit);
    }
}