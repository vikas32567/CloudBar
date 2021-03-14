using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Context;

namespace WebApp.Services
{
    public interface ISpiritService
    {
        List<Spirit> GetSpiritsByDapper();
        List<Spirit> GetSpiritsByEf();
        Spirit GetSpirit(long spiritId);
        Task<Spirit> AddSpirit(Spirit spirit);
        Task<Spirit> UpdateSpirit(Spirit spirit);
    }
}