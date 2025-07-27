using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class DefaultCorntroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
