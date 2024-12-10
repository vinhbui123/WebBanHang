using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;
using WebBanHang.Extension;
using WebBanHang.Helpper;
using WebBanHang.Model;
using WebBanHang.ModelViews;
namespace WebBanHang.Controllers
{
    [Authorize]
	public class AccountController : Controller
	{

		private readonly WebBanHangContext _db;

		public AccountController(WebBanHangContext db)
		{
			_db = db;
		}

        public IActionResult ValidateName(string fullName)
		{
			try
			{
                var Name = _db.Customers.SingleOrDefault(x => x.FullName.ToLower() == fullName.ToLower());
				if (Name != null)
                    return Json(data: "Name" + Name + "was used : ");

                return Json(data: "Name : " + Name + " can use");
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                ViewBag.ErrorMessage = ex.Message;
                return Json(data: "error");
            }
        }


        public IActionResult ValidatePhone(string PhoneNumber)
        {
            try
            {
                var phoneNumber = _db.Customers.SingleOrDefault(x => x.Phone.ToLower() == PhoneNumber.ToLower());
                if (phoneNumber != null)
                    return Json(data: "Số điện thoại : " + PhoneNumber + " đã được sử dụng");

                return Json(data: "Số điện thoại : " + PhoneNumber + " có thể sử dụng");
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                ViewBag.ErrorMessage = ex.Message;
                return Json(data: "Đã xảy ra lỗi, vui lòng thử lại sau.");
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
		public IActionResult MyAccount()
		{
			var Idtk = HttpContext.Session.GetString("CustomerId");
			if (Idtk != null)
			{
                var khachhang = _db.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(Idtk));
				if (khachhang != null)
					return View();
			}

			return RedirectToAction("Login");
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
                    // Check if a customer with the same email or name already exists
					//AnyAsync stop when find matching
                    bool customerExists = await _db.Customers.AnyAsync(c =>
                        c.Email.ToLower() == account.Email.Trim().ToLower() ||
                        c.FullName.ToLower() == account.FullName.Trim().ToLower());

                    if (customerExists)
                    {
                        ModelState.AddModelError("", "A customer with the same name or email already exists.");
                        return View(account);
                    }

                    // Create a new customer if no duplicate is found
                    try
                    {
                        Customer kh = new Customer
                        {
                            FullName = account.FullName,
                            Phone = account.PhoneNumber.Trim().ToLower(),
                            Email = account.Email.Trim().ToLower(),
                            Password = account.Password.Trim().ToLower(),
                            Active = true,
                            Salt = Utilities.GetRandomKey(),
                            CreateDate = DateTime.Now
                        };

                        _db.Add(kh);
                        await _db.SaveChangesAsync();

                        // Save customer session
                        HttpContext.Session.SetString("CustomerId", kh.CustomerId.ToString());
                        return RedirectToAction("My account", "Home");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = "An error occurred while creating the account. Please try again.";
                        return View(account);
                    }
                }
                    return View(account);   
            }
            catch
            {
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
                if (customer.UserName.Equals("admin@gmail.com") && customer.Password.Equals("123"))
                {
                    return Redirect("/Admin");
                }


                if (ModelState.IsValid)
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
					//if (kh.Active == false) return RedirectToAction("ThongBao", "Accounts");

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
			return RedirectToAction("index", "Home");
		}

	}
}
