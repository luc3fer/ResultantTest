using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ResultantTest.Models;

namespace ResultantTest.DAL
{
    public class CurrencyHandler : ICurrencyHandler
    {
        private const string _url = "http://phisix-api3.appspot.com/stocks.json";

        public IEnumerable<CurrencyEntity> GetCurrencyEntity()
        {
            using (var handler = new HttpClientHandler { UseDefaultCredentials = true })
            {
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(_url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsAsync<StockInfo>().Result;
                        foreach (var stock in result?.Stocks)
                        {
                            yield return new CurrencyEntity
                            {
                                Name = stock.Name,
                                Volume = stock.Volume,
                                Amount = stock.Price?.Amount.ToString("F"),
                            };
                        }
                    }
                    else
                        throw new Exception(response.Content.ToString());
                }
            }
        }
    }
}
