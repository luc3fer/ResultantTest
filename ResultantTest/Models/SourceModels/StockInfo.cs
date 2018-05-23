using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultantTest.Models
{
    public class StockInfo
    {
        [JsonProperty(PropertyName = "stock")]
        public List<Stock> Stocks { get; set; }

        [JsonProperty(PropertyName = "as_of")]
        public DateTime UpdateDateTime { get; set; }
    }
}
