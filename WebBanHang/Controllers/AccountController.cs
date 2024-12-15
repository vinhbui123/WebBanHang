using Humanizer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Security.Claims;
using WebBanHang.Extension;
using WebBanHang.Helpper;
using WebBanHang.Migrations;
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


        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("My_account.cshtml", Name = "My account")]
        public async Task<IActionResult> MyAccount()
        {
            try
            {
                var Idtk = HttpContext.Session.GetString("CustomerId");
                if (Idtk != null)
                {
                    //Retrieve a customer record from the Customers table based on the CustomerId and Idtk variable likely contains the ID of the customer you want to find.
                    var khachhang = _db.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(Idtk));
                    //It’s often shorter and easier to write for simple queries than linq.
                    if (khachhang != null)
                        return View();
                }


            }
            catch { }

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
            //Asyn :Indicates that the method supports asynchronous operations.
            //Improves performance by freeing up the thread while waiting for I/O-bound operations
            //(like database queries, file I/O, or API calls) to complete.
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
                        String salt = Utilities.GetRandomKey();
                        Customers kh = new Customers
                        {
                            FullName = account.FullName,
                            Phone = account.PhoneNumber.Trim().ToLower(),
                            Address = account.Address.Trim().ToLower(),
                            Birthday = account.Birthday,
                            Email = account.Email.Trim().ToLower(),
                            Password = (account.Password.Trim().ToLower() + salt.Trim()).ToMD5(),
                            Active = true,
                            Salt = salt,
                            CreateDate = DateTime.Now
                        };

                        _db.Add(kh);
                        await _db.SaveChangesAsync();

                        // Save customer session
                        HttpContext.Session.SetString("CustomerId", kh.CustomerId.ToString());
                        return RedirectToAction("Login", "Account");
                        //return RedirectToAction("My account", "Home");
                    }
                    catch (Exception)
                    {
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
                    ModelState.AddModelError("", "An error occurred during logout:");
                    // Admin login - redirect to Admin dashboard
                    var adminClaims = new List<Claim>
            {
                    new Claim(ClaimTypes.Name, "Admin"),
                    new Claim(ClaimTypes.Role, "Admin")
            };

                    var adminIdentity = new ClaimsIdentity(adminClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var adminPrincipal = new ClaimsPrincipal(adminIdentity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, adminPrincipal);

                    return Redirect("/Admin");
                }

                if (ModelState.IsValid)
                {
                    bool isEmail = Utilities.IsValidEmail(customer.UserName);
                    if (!isEmail) return View(customer);

                    var kh = _db.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);
                    if (kh == null) return RedirectToAction("Signup");

                    // Check password
                    string pass = (customer.Password + kh.Salt.Trim()).ToMD5();
                    bool passMatch = await _db.Customers.AnyAsync(c => c.Password.ToLower() == pass);

                    if (!passMatch)
                    {
                        ModelState.AddModelError("", "Password is incorrect.");
                        return View(customer);
                    }

                    ModelState.AddModelError("", "Login success");
                    // Check if account is disabled
                    // Uncomment if needed:
                    // if (!kh.Active) return RedirectToAction("ThongBao", "Accounts");

                    // Save session data
                    HttpContext.Session.SetString("CustomerId", kh.CustomerId.ToString());

                    // Create identity and issue authentication cookie
                    var claims = new List<Claim>
            {
                    new Claim(ClaimTypes.Name, kh.FullName),
                    new Claim("CustomerId", kh.CustomerId.ToString())
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    // Redirect to the return URL if available, otherwise redirect to home
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If model state is invalid
                    return View(customer);
                }
            }
            catch
            {
                // Handle errors and redirect to signup
                return RedirectToAction("Signup", "Account");
            }
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                // Sign out the user from the authentication scheme
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                // Remove the "CustomerId" from the session
                HttpContext.Session.Remove("CustomerId");

                // Redirect to the "Home" page
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during sign-out
                ModelState.AddModelError("", "An error occurred during logout:");
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
