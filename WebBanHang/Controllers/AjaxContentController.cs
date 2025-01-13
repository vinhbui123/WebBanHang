using Microsoft.AspNetCore.Mvc;

namespace WebBanHang.Controllers
{
	public class AjaxContentController : Controller
	{
		public IActionResult Headerfavorite()
		{
			return ViewComponent("NumberCart"); // Ensure this matches the view component name
		}
	}
}
