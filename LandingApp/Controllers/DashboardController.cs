using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LandingApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Appmenu() => View();
    }
}
