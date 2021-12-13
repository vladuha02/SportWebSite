using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportWebSite.Domain.Authorization;

namespace SportWebSite.Controllers
{
    [Authorize(Roles = Roles.ADMIN)]
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
