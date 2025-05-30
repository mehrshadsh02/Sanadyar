using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LandingApp.Services;

namespace LandingApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly AppLinks _links;

        public DashboardController(AppLinks links)
        {
            _links = links;
        }

        public IActionResult Appmenu()
        {
            ViewBag.FinanceApp = _links.FinanceApp;
            ViewBag.SalaryApp = _links.SalaryApp;
            ViewBag.InventoryApp = _links.InventoryApp;
            ViewBag.CashApp = _links.CashApp;
            ViewBag.ReportApp = _links.ReportApp;

            return View();
        }
    }
}
