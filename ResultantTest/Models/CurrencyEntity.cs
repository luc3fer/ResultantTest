using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultantTest.Models
{
    public class CurrencyEntity
    {
        public string Name { get; set; }

        public float? Amount { get; set; }

        public int Volume { get; set; }

        public float PercentChange { get; set; }
    }
}
