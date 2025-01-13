using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Drawing.Printing;
using WebBanHang.Model;
using WebBanHang.ModelViews;
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
            int pageSize = 12;
            var pageNumber = page == null || page < 1 ? 1 : page.Value;

            // Fetch the product list from the database
            var productList = _db.Products.AsNoTracking().OrderBy(x => x.ProductName);
            // Create paginated list
            PagedList<Product> list = new PagedList<Product>(productList, pageNumber, pageSize);
            // Return the paginated product list and cart data
            return View(list);
        }



        [AllowAnonymous]
		[HttpPost]
		[Route("FindProduct", Name = "find")]
		public ActionResult FindProduct(string searchQuery, int? page)
		{
			if (string.IsNullOrWhiteSpace(searchQuery))
			{
				// Redirect to index if search query is empty
				return RedirectToAction("Index");
			}

			// Case-insensitive search for products matching the query
			int pageSize = 12;
			int pageNumber = page ?? 1;
			var productList = _db.Products
				.AsNoTracking()
				.Where(x => x.ProductName.ToLower().Contains(searchQuery.ToLower()))
				.OrderBy(x => x.ProductName);

            PagedList<Product> list = new PagedList<Product>(productList, pageNumber, pageSize);
            return View(list);
        }
    }
}
