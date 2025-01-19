using Microsoft.AspNetCore.Mvc;
using WebBanHang.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace WebBanHang.Areas.admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
		private readonly WebBanHangContext _context;

		public HomeController(WebBanHangContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetDashboardData()
		{
			// Lấy dữ liệu từ database
			var totalProducts = await _context.Products.CountAsync();
			var totalUsers = await _context.Customers.CountAsync();
			var totalRevenue = await _context.Orders.SumAsync(o => o.TotalPrice);

			// Trả về dữ liệu dưới dạng JSON
			return Json(new
			{
				totalProducts = totalProducts,
				totalUsers = totalUsers,
				totalRevenue = totalRevenue
			});
		}
	}
}
