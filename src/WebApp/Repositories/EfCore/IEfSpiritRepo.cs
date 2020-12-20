using System.Collections.Generic;
using WebApp.Context;

namespace WebApp.Repositories
{
    public interface IEfSpiritRepo
    {
        List<Spirit> GetSpirits();
    }
}