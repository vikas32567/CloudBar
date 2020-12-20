using System.Collections.Generic;
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

        public List<Spirit> GetSpiritsByDapper()
        {
            return dapperSpiritRepo.GetSpirits();
        }
        
        public List<Spirit> GetSpiritsByEf()
        {
            return efSpiritRepo.GetSpirits();
        }
        
    }
}