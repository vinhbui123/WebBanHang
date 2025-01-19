using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Linq;
using System.Threading.Tasks;
using PagedList.Core;
using WebBanHang.Model;
using Microsoft.AspNetCore.Authorization;

namespace WebBanHang.Areas.admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderAdminController : Controller
	{
		private readonly WebBanHangContext _context;

		public OrderAdminController(WebBanHangContext context)
		{
			_context = context;
		}

		// GET: admin/OrderAdmin
		public IActionResult Index(int page = 1, string OrderStatus = "")
		{
			var pageNumber = page;
			var pageSize = 20;

			var query = _context.Orders.AsNoTracking()
				.Include(o => o.OrderItems)
				.Include(o => o.Ships)
				.Include(o => o.Customer);
			

			var lsOrders = query.OrderByDescending(x => x.OrderId).ToPagedList(pageNumber, pageSize);

			ViewBag.CurrentOrderStatus = OrderStatus;
			ViewBag.CurrentPage = pageNumber;

			return View(lsOrders);
		}

		public IActionResult Filter(string OrderStatus = "")
		{
			var url = $"/Admin/OrderAdmin?";

			if (!string.IsNullOrEmpty(OrderStatus))
			{
				url += $"OrderStatus={OrderStatus}&";
			}

			if (url.EndsWith("&"))
			{
				url = url.Substring(0, url.Length - 1);
			}

			if (string.IsNullOrEmpty(OrderStatus))
			{
				url = "/Admin/OrderAdmin";
			}

			return Json(new { status = "success", redirectUrl = url });
		}

		// GET: admin/OrderAdmin/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var order = await _context.Orders
				.Include(o => o.OrderItems)
				.Include(o => o.Ships)
				.Include(o => o.Customer)
				.FirstOrDefaultAsync(m => m.OrderId == id);

			if (order == null)
			{
				return NotFound();
			}

			var viewModel = new OrderAdminViewModel
			{
				Order = order,
				OrderItems = order.OrderItems.ToList(),
				Ship = order.Ships.FirstOrDefault()
			};

			return View(viewModel);
		}

		// POST: admin/OrderAdmin/EditOrderStatus
		[HttpPost]
		public async Task<IActionResult> EditOrderStatus(int orderId, string orderStatus)
		{
			var order = await _context.Orders.FindAsync(orderId);
			if (order == null)
			{
				return NotFound();
			}

			order.OrderStatus = orderStatus;
			_context.Update(order);
			await _context.SaveChangesAsync();

			return Json(new { success = true });
		}

		// POST: admin/OrderAdmin/EditShipStatus
		[HttpPost]
		public async Task<IActionResult> EditShipStatus(int shipId, string shipStatus)
		{
			var ship = await _context.Ships.FindAsync(shipId);
			if (ship == null)
			{
				return NotFound();
			}

			ship.ShipStatus = shipStatus;
			_context.Update(ship);
			await _context.SaveChangesAsync();

			return Json(new { success = true });
		}
	}
}