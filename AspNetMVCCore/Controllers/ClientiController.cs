using AspNetMVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCCore.Controllers
{
    public class ClientiController : Controller
    {
        private readonly NorthwindContext _northwindContext;

        public ClientiController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        public IActionResult ElencoClienti()
        {
            var query = _northwindContext.Customers.ToList();

            return View(query);
        }
        [HttpGet]
        public IActionResult ClientiPerPaese()
        {
            //var query = _northwindContext.Customers.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult ClientiPerPaese(string paese)
        {
            var query = _northwindContext.Customers.Where(c => c.Country == paese).ToList();

            ViewBag.Paese = paese;

            return View(query);
        }

        public IActionResult ClientiCombo(string paese)
        {
            var query = _northwindContext.Customers.GroupBy(c => c.Country).Select(k => k.Key).ToList();
            ViewBag.Combo = query;

            var query1 = _northwindContext.Customers.Where(c => c.Country == paese).ToList();
            return View(query1);
        }
    }
}
