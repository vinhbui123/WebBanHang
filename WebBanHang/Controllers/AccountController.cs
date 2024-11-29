using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebBanHang.Helpper;
using WebBanHang.Models;
using WebBanHang.ModelViews;
namespace WebBanHang.Controllers
{
	public class AccountController : Controller
	{
		private readonly WebBanHangContext _db;

		public AccountController(WebBanHangContext db) {
			_db = db;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		[Microsoft.AspNetCore.Mvc.Route("Login.html", Name = "Sign up")]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[Microsoft.AspNetCore.Mvc.Route("Login.html", Name = "Sign up")]
		public async Task<IActionResult> Signup([Bind("CustomerId, FullName, PassWord, Phone, Email")] SignUpVM customer) {
			try
			{
				if (ModelState.IsValid)
				{
					String RandomKey = Utilities.GetRandomKey();
					Customer kh = new Customer
					{
						FullName = customer.FullName,
						Phone = customer.PhoneNumber.Trim().ToLower(),
						Email = customer.Email.Trim().ToLower(),
						Password = customer.Password.Trim().ToLower(),
						IsActive = true,
						Salt = RandomKey.Trim(),
						Created = DateTime.Now
					};
					try
					{
						_db.Add(kh);
						await _db.SaveChangesAsync();
						//save Customer id
						HttpContext.Session.SetString("CustomerId", kh.CustomerId.ToString());
						var tk_id = HttpContext.Session.GetString("CustomerId");
						//identity
						var claim = new List<Claim>
						{
							new Claim(ClaimTypes.Name, kh.FullName),
							new Claim("CustomerId", kh.CustomerId.ToString())
						};
						ClaimsIdentity claimsIdentity = new ClaimsIdentity(claim, "login");
						ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
						await HttpContext.SignInAsync(claimsPrincipal);
						return RedirectToAction("Dashboard", "Accounts");
					}
					catch
					{
						return RedirectToAction("Signup", "Accounts");
					}
				}
				else
				{
					return View(customer);
				}
			}
			catch { 
				return View(customer);
			}
		}
	}
}
