using BuisnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using BuisnessLayer.Validations;


namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Listesi";
            var values = portfolioManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.v1 = "Proje Ekle";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Ekle";
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            ViewBag.v1 = "Proje Ekle";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Ekle";

            PortfolioValidatior validations = new PortfolioValidatior();
            ValidationResult results = validations.Validate(portfolio);
            if (results.IsValid)
            {
                portfolioManager.Tadd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidatior validations = new PortfolioValidatior();
            ValidationResult results = validations.Validate(portfolio);
            if (results.IsValid)
            {
                portfolioManager.Tadd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            portfolioManager.TUpdate(portfolio);
            return View();
        }
    }
}
