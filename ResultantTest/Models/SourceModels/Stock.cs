using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultantTest.Models
{
    public class Stock
    {
        public string Name { get; set; }

        public Price Price { get; set; }

        [JsonProperty(PropertyName = "percent_change")]
        public float PercentChange { get; set; }

        public int Volume { get; set; }

        public string Symbol { get; set; }
    }
}
