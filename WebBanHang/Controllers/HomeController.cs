using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
			var pageNumber = page == null || page < 1 ? 1 : page.Value;
			var productList = _db.Products.AsNoTracking().OrderBy(x => x.ProductName);
			PagedList<Products> list = new PagedList<Products>(productList, pageNumber, pageSize);

			return View(list);
		}

		public IActionResult Contact()
		{
			return View();
		}
		
		
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
