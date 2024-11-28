using Microsoft.AspNetCore.Mvc;
using WebBanHang.Models;
namespace WebBanHang.Controllers
{
	public class AccountController : Controller
	{
		private readonly WebBanHangContext db = new WebBanHangContext();
		[HttpGet]
		public IActionResult Login()
		{
			if (HttpContext.Session.GetString("Email") == null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}


		public IActionResult Login(Account account)
		{
			if (HttpContext.Session.GetString("Email") == null)
			{
				var u = db.Accounts.Where(x=>x.Email.Equals(account.Email) && x.Password.Equals(account.Password)).FirstOrDefault();
				if (u != null)
				{
					HttpContext.Session.SetString("Email", u.Email.ToString());
					return RedirectToAction("Index", "Home");
				}
			}
			return View();
		}
	}
}
