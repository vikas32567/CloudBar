using System.Collections.Generic;
using WebApp.Context;

namespace WebApp.Services
{
    public interface ISpiritService
    {
        List<Spirit> GetSpiritsByDapper();
        List<Spirit> GetSpiritsByEf();
    }
}