using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCCore.Controllers
{
    public class ProvaController : Controller
    {
        public IActionResult Pagina1()
        {
            return View();
        }
    }
}
