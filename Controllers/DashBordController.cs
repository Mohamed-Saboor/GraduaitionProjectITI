using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduaitionProjectITI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DashBordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
