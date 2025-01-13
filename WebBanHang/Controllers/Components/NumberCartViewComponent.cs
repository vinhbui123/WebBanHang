using Microsoft.AspNetCore.Mvc;
using WebBanHang.ModelViews;

namespace WebBanHang.Controllers.Components
{
	public class NumberCartViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var cart = HttpContext.Session.Get<List<CartItem>>("Giohang");
			return View(cart);
		}
	}
}
