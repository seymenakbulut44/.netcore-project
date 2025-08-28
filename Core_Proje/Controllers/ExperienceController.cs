using BuisnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Deneyim Listesi";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Listesi";
            var values = experienceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            ViewBag.v1 = "Deneyim Ekleme";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Ekleme";
            experienceManager.Tadd(experience);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetByID(id);
            experienceManager.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult EditExperience(int id)
        {
            ViewBag.v1 = "Deneyim Güncelleme";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Güncelleme";
            var values = experienceManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
