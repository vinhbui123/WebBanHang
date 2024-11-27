using Microsoft.AspNetCore.Mvc;

namespace WebBanHang.Areas.admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
