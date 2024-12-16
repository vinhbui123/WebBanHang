using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebBanHang.Model;
using X.PagedList;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
		private readonly ILogger<HomeController> _logger;
		private readonly WebBanHangContext _db;

		public HomeController(ILogger<HomeController> logger, WebBanHangContext db)
		{
			_logger = logger;
			_db = db;
		}


		public IActionResult Index(int? page)
		{
			int pageSize = 9;
			var pageNumber = page == null || page < 1  ? 1 : page.Value;
			var productList = _db.Products.AsNoTracking().OrderBy(x => x.ProductName);
			PagedList<Product> list = new PagedList<Product>(productList, pageNumber, pageSize);
			return View(list);
		}


		[AllowAnonymous]
		[HttpPost]
		[Route("FindProduct", Name = "find")]
		public IActionResult FindProduct(string searchQuery, int? page)
		{
			if (string.IsNullOrWhiteSpace(searchQuery))
			{
				// Redirect to index if search query is empty
				return RedirectToAction("Index");
			}

			// Case-insensitive search for products matching the query
			int pageSize = 9;
			int pageNumber = page ?? 1;

			var productList = _db.Products
				.AsNoTracking()
				.Where(x => x.ProductName.ToLower().Contains(searchQuery.ToLower()))
				.OrderBy(x => x.ProductName);

			var pagedList = new PagedList<Product>(productList, pageNumber, pageSize);

			return View("Index", pagedList);
		}
	}
}
