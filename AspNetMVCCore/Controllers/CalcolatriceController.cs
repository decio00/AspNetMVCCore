using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCCore.Controllers
{
    public class CalcolatriceController : Controller
    {
        [HttpGet]
        public IActionResult Calcolatrice()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Calcolatrice")]
        public IActionResult CalcolatricePost()
        {

            double.TryParse(HttpContext.Request.Form["txt7"], out double n1);
            double.TryParse(HttpContext.Request.Form["txt8"].ToString(), out double n2);
            ViewData["Num1"] = n1;
            ViewBag.Num2 = n2;
            ViewBag.Risultato = n1 + n2;

            return View();
        }

    }
}
