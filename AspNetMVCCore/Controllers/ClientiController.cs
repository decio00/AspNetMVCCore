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
        public IActionResult ClientiComboTag(string paese)
        {
            var query = _northwindContext.Customers.GroupBy(c => c.Country).Select(k => k.Key).ToList();
            ViewBag.Combo = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(query, paese);

            var query1 = _northwindContext.Customers.Where(c => c.Country == paese).ToList();
            return View(query1);
        }
        public IActionResult ClientiOrdini()
        {
            //var query = _northwindContext.Join(_northwindContext.Orders, _northwindContext.Customers, )

            var query = _northwindContext.Customers
                .Join(_northwindContext.Orders,
                    c => c.CustomerId,
                    o => o.CustomerId,
                    (c, o) => new ClientiOrdini { OrderId =  o.OrderId, OrderDate =  o.OrderDate.Value, CompanyName = c.CompanyName, City = c.City, Country = c.Country })
                .Select(result => result);


            return View(query.ToList());
        }
    }
}
