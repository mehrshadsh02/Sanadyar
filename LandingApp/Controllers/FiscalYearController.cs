using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LandingApp.ViewModels;

namespace LandingApp.Controllers
{
    public class FiscalYearController : Controller
    {
        [HttpGet]
        public IActionResult Select()
        {
            var selectedYear = HttpContext.Session.GetInt32("FiscalYear") ?? 1404;
            var model = new FiscalYearViewModel
            {
                SelectedYear = selectedYear,
                AvailableYears = Enumerable.Range(1401, 10).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SetYear(int selectedYear)
        {
            HttpContext.Session.SetInt32("FiscalYear", selectedYear);
            return RedirectToAction("Appmenu", "Dashboard");
        }
    }
}
