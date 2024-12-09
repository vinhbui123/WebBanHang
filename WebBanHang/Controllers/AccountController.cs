using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebBanHang.Extension;
using WebBanHang.Helpper;
using WebBanHang.Models;
using WebBanHang.ModelViews;
namespace WebBanHang.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{

		private readonly WebBanHangContext _db;

		public AccountController(WebBanHangContext db) {
			_db = db;
		}

		public IActionResult ValidatePhone(string phoneNumber)
		{
			try
			{
				var khachhang = _db.Customers.SingleOrDefault(x => x.Phone.ToLower() == phoneNumber.ToLower());
				if (khachhang == null)
					return Json(data: "Số điện thoại : " + phoneNumber + " đã được sử dụng");
				return Json(data: true);
			} catch
			{
				return Json(data: true);
			}
			
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult ValidateEmail(string Email)
		{
			try
			{
				var khachhang = _db.Customers.AsNoTracking().SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
				if (khachhang == null)
					return Json(data: "Email : " + Email + " đã được sử dụng");
				return Json(data: true);
			}
			catch
			{
				return Json(data: true);
			}
		}
        [Microsoft.AspNetCore.Mvc.Route("My_account.cshtml", Name = "My account")]
		public IActionResult MyAccount() {
        var Idtk = HttpContext.Session.GetString("CustomerId");
			if (Idtk != null)
			{
				return RedirectToAction("Index", "Home");
    }

            return View();
}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		[Microsoft.AspNetCore.Mvc.Route("Signup.html", Name = "Signup")]
		public IActionResult Signup()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[Microsoft.AspNetCore.Mvc.Route("Signup.html", Name = "Sign up")]
		public async Task<IActionResult> Signup(SignUpVM account)
		{
			try
			{
				if (ModelState.IsValid)
				{
					String RandomKey = Utilities.GetRandomKey();
                    // Simulate adding a customer without interacting with the database
                    try
                    {
                        Customer kh = new Customer
                        {
                            FullName = account.FullName,
                            Phone = account.PhoneNumber.Trim().ToLower(),
                            Email = account.Email.Trim().ToLower(),
                            Password = account.Password.Trim().ToLower(),
                            IsActive = true,
                            Salt = Utilities.GetRandomKey(),
                            Created = DateTime.Now
                        };

                        _db.Add(kh);
                        await _db.SaveChangesAsync();

                        // Simulate saving customer session
                        HttpContext.Session.SetString("CustomerId", kh.CustomerId.ToString());
                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception ex)
                    {
						ViewBag.ErrorMessage = "error";
                        return RedirectToAction("Signup", "Account");
                    }

                }
                else
				{
                    return View(account);
                }
			}
			catch { 
				return View(account);
			}
		}

		[HttpGet]
        [AllowAnonymous]
        [Microsoft.AspNetCore.Mvc.Route("Login.html", Name = "Login")]
        public IActionResult Login(string? returnUrl = null)
        {
            var Idtk = HttpContext.Session.GetString("CustomerId");
			if (Idtk != null)
			{
				return RedirectToAction("Index", "Home");
			}

            return View();
        }



        [HttpPost]
		[AllowAnonymous]
		[Microsoft.AspNetCore.Mvc.Route("Login.html", Name = "Login")]
		public async Task<IActionResult> Login(LoginVm customer, string? returnUrl = null)
		{
			try
			{

				if(ModelState.IsValid)
				{
					bool isEmail = Utilities.IsValidEmail(customer.UserName);
					if (!isEmail) return View(customer);
					var kh = _db.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);
					if (kh == null) return RedirectToAction("Signup");

					//check password is correct if not return to view
					string pass = (customer.Password + kh.Salt.Trim().ToMD5());
					if (customer.Password != pass)
					{
						ViewBag.Error = "sai mk";
						return View(customer);
					}
					//check account is disable
					if (kh.IsActive == false) return RedirectToAction("ThongBao","Accounts");

					//save session CustomerId
					HttpContext.Session.SetString("CustomerId", kh.CustomerId.ToString());
					var tkID = HttpContext.Session.GetString("CustomerId");
					//Identity
					var claim = new List<Claim>
						{
							new Claim(ClaimTypes.Name, kh.FullName),
							new Claim("CustomerId", kh.CustomerId.ToString())
						};

				}
			} 
			catch 
			{
				return RedirectToAction("Signup", "Account");
			}
			return View(customer);
		}

	}
}
