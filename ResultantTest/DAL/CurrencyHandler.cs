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
        public List<CurrencyEntity> GetCurrencyEntity()
        {
            using (var handler = new HttpClientHandler { UseDefaultCredentials = true })
            {
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync("http://phisix-api3.appspot.com/stocks.json").Result;

                    List<CurrencyEntity> CurrencyEntities = new List<CurrencyEntity>();
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsAsync<StockInfo>().Result;
                        foreach (var stock in result?.Stocks)
                        {
                            CurrencyEntities.Add(new CurrencyEntity
                            {
                                Name = stock.Name,
                                Volume = stock.Volume,
                                Amount = stock.Price?.Amount,
                                PercentChange = stock.PercentChange
                            });
                        }
                    }
                    else
                    {
                        //throw new HttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                    }

                    return CurrencyEntities;
                }
            }
        }
    }
}
