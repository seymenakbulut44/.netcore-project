using BuisnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Servis Listesi";
            ViewBag.v2 = "Servisler";
            ViewBag.v3 = "Servis Listesi";
            var values = serviceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.v1 = "Servis Listesi";
            ViewBag.v2 = "Servisler";
            ViewBag.v3 = "Servis Listesi";
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.Tadd(service);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.TGetByID(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult EditService(int id)
        {
            ViewBag.v1 = "Servis Listesi";
            ViewBag.v2 = "Servisler";
            ViewBag.v3 = "Servis Listesi";
            var values = serviceManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
