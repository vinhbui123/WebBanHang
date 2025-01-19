using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Model;
using WebBanHang.ModelViews;

namespace WebBanHang.Controllers
{
    public class OrderController : Controller
    {
        private WebBanHangContext _db;

        public OrderController(WebBanHangContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            // Retrieve the CustomerId from the session
            var customerId = HttpContext.Session.GetString("CustomerId");

            // If the session data is not set, redirect to Login
            if (string.IsNullOrEmpty(customerId))
            {
                return RedirectToAction("Login", "Account");
            }

            // Retrieve customer information from the database
            var customer = await _db.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CustomerId.ToString() == customerId);

            // If customer is not found, return to login
            if (customer == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Retrieve cart items for the customer (assuming CartItem is a model that stores user's cart data)
            var cart = HttpContext.Session.Get<List<CartItem>>("Giohang");

            // Prepare the OrderVm which includes both the user information and cart items
            var orderVm = new OrderVm
            {
                UserInformation = new PaymentUserInformationVM
                {
                    CustomerId = customer.CustomerId,
                    FullName = customer.FullName,
                    PhoneNumber = customer.Phone,
                    Address = customer.Address,
                },
                CartItems = cart
            };

            // Pass the OrderVm to the view
            return View(orderVm);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderVm orderVm, string paymentMethod)
        {
            var kh = HttpContext.Session.GetString("CustomerId");
            var cart = HttpContext.Session.Get<List<CartItem>>("Giohang");

            PaymentUserInformationVM model = new PaymentUserInformationVM();
            if (kh != null)
            {
                var khachhang = _db.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(kh));
                model.CustomerId = khachhang.CustomerId;
                model.FullName = khachhang.FullName;
                model.PhoneNumber = khachhang.Phone;
                model.Address = khachhang.Address;
                _db.Update(khachhang);
            }

            try
            {
                Order orderkh = new Order
                {
                    CustomerId = model.CustomerId,
                    TotalPrice = Convert.ToInt32(cart.Sum(x => x.TotalPrice)),
                    OrderDate = DateTime.Now,
                    OrderStatus = "da dat hang",
                    PaymentMethodName = paymentMethod,
                    Ship = true
                };

                _db.Add(orderkh);
                _db.SaveChanges();  // Save to get the OrderId populated

                // Now that the order is saved and OrderId is populated, store it in the session
                HttpContext.Session.SetString("OrderId", orderkh.OrderId.ToString());

			}
            catch
            {
                throw new Exception("khong the tao don hang");
            }

			foreach (var item in cart)
            {
                OrderItem orderItem = new OrderItem();
				orderItem.OrderId = Convert.ToInt32(HttpContext.Session.GetString("OrderId"));
				orderItem.ProductId = item.product.ProductId;
                orderItem.Quantity = item.amount;
                orderItem.ListPrice = item.TotalPrice;
                
                _db.Add(orderItem);
			    _db.SaveChanges();  // Save changes in bulk for better performance
            }

            // Optionally, clear the cart after the order is placed
            HttpContext.Session.Remove("Giohang");

            return RedirectToAction("index", "Home");
            // Redirect to an order confirmation or another relevant page
        }

    }
}
