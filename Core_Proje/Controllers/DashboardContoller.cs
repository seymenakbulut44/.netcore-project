using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class DashboardContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
