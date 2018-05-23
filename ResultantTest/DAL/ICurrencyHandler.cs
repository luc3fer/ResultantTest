using ResultantTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultantTest.DAL
{
    public interface ICurrencyHandler
    {
        List<CurrencyEntity> GetCurrencyEntity();
    }
}
