using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LandingApp.Services;

namespace LandingApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Appmenu()
        {
            return View();
        }
    }
}
