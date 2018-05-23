using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResultantTest.DAL;
using ResultantTest.Models;

namespace ResultantTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencyHandler _currencyHandler;

        public HomeController(ICurrencyHandler currencyHandler)
        {
            _currencyHandler = currencyHandler;
        }

        public IActionResult Index()
        {
            return View(CurrenciesList());
        }

        public List<CurrencyEntity> CurrenciesList()
        {
            ViewData["Message"] = "Your application description page.";

            return _currencyHandler.GetCurrencyEntity();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
