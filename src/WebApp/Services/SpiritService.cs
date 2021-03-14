using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Context;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class SpiritService : ISpiritService
    {
        private readonly IDapperSpiritRepo dapperSpiritRepo;
        private readonly IEfSpiritRepo efSpiritRepo;

        public SpiritService(IDapperSpiritRepo dapperSpiritRepo, IEfSpiritRepo efSpiritRepo)
        {
            this.dapperSpiritRepo = dapperSpiritRepo;
            this.efSpiritRepo = efSpiritRepo;
        }

        public List<Spirit> GetSpiritsByDapper() => dapperSpiritRepo.GetSpirits();
        
        public List<Spirit> GetSpiritsByEf() => efSpiritRepo.GetSpirits();

        public Spirit GetSpirit(long spiritId) => efSpiritRepo.GetSpirit(spiritId);

        public async Task<Spirit> AddSpirit(Spirit spirit) => await efSpiritRepo.AddSpirit(spirit);

        public async Task<Spirit> UpdateSpirit(Spirit spirit)
        {
            var tempSpirit = GetSpirit(spirit.Id);

            tempSpirit.Name = spirit.Name;
            tempSpirit.Price = spirit.Price;
            tempSpirit.Stock = spirit.Stock;

            return await efSpiritRepo.UpdateSpirit(tempSpirit);
        }
        
    }
}