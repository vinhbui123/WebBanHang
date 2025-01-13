using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebBanHang.Model;
using WebBanHang.ModelViews;

public class ShoppingCartController : Controller
{
	private readonly ILogger<ShoppingCartController> _logger;
	private readonly WebBanHangContext _db;

	public ShoppingCartController(ILogger<ShoppingCartController> logger, WebBanHangContext db)
	{
		_logger = logger;
		_db = db;
	}

	public List<CartItem> Giohang
	{
		get
		{
			var gh = HttpContext.Session.Get<List<CartItem>>("Giohang");
			if (gh == null)
			{
				gh = new List<CartItem>(); // Initialize empty if not found
			}
			return gh;
		}
	}

	public IActionResult Index()
	{
		var cartItems = Giohang; // Assuming Giohang is the list of cart items
		int totalAmount = cartItems.Sum(item => item.amount);  // Sum all the 'amount' values

		ViewBag.TotalAmount = totalAmount; // Passing total amount to the view

		return View(cartItems); // Return the cart items to the view
	}

	[HttpPost]
	public IActionResult AddToCart(int productId, int? amount)
	{
		if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account");

		List<CartItem> giohang = Giohang;
		try
		{
			CartItem item = Giohang.FirstOrDefault(p => p.product.ProductId == productId);

			if (item != null)
			{
				if (amount.HasValue)
				{
					item.amount = amount.Value;
				}
				else
				{
					item.amount++;  // Increase quantity if no amount is provided
				}
			}
			else
			{
				Product? hh = _db.Products.FirstOrDefault(p => p.ProductId == productId);

				item = new CartItem
				{
					amount = amount.HasValue ? amount.Value : 1,
					product = hh
				};

				giohang.Add(item);
			}

			HttpContext.Session.Set<List<CartItem>>("Giohang", giohang);
			return Json(new { success = true, message = "Product added to cart successfully!" });
		}
		catch (Exception ex)
		{
			return Json(new { success = false, message = "An error occurred: " + ex.Message });
		}
	}

	public IActionResult RemoveFromCart(int productId)
	{
		var giohang = Giohang ?? new List<CartItem>();
		var item = giohang.FirstOrDefault(p => p.product.ProductId == productId);
		if (item != null)
		{
			giohang.Remove(item);
			HttpContext.Session.Set<List<CartItem>>("Giohang", giohang);
		}
		return Json(new { success = true, message = "Product removed from cart successfully!" });
	}

	[HttpPost]
	public IActionResult UpdateCart(int productId, int? amount)
	{
		var giohang = HttpContext.Session.Get<List<CartItem>>("Giohang");
		try
		{
			if (giohang != null)
			{
				CartItem item = giohang.SingleOrDefault(p => p.product.ProductId == productId);
				if (item != null && amount.HasValue)
				{
					item.amount = amount.Value;
					HttpContext.Session.Set<List<CartItem>>("Giohang", giohang);
				}
			}
			return Json(new { success = true, message = "Product update to cart successfully!" });
		}
		catch (Exception ex)
		{
			return Json(new { success = false, message = "An error occurred: " + ex.Message });
		}
	}

	// New method to get the current cart item count
	public IActionResult GetCartItemCount()
	{
		var giohang = Giohang;
		int count = giohang?.Sum(item => item.amount) ?? 0;
		return Json(new { count = count });
	}
}
