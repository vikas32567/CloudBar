using System.Collections.Generic;
using WebApp.Context;

namespace WebApp.Repositories
{
    public interface IDapperSpiritRepo
    {
        List<Spirit> GetSpirits();
    }
}