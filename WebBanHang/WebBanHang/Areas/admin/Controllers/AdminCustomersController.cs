using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using WebBanHang.Models;

namespace WebBanHang.Areas.admin.Controllers
{
    [Area("admin")]
    public class AdminCustomersController : Controller
    {
        private readonly DbNet4Context _context;

        public AdminCustomersController(DbNet4Context context)
        {
            _context = context;
        }

		// GET: admin/AdminCustomers
		
		public IActionResult Index(int? page)
		{
			var pageNumber = page == null || page <= 0 ? 1 : page.Value;
			var pageSize =20;

			var lsCustomers = _context.Customers.AsNoTracking()
												.OrderByDescending(x => x.CustomerId);

			PagedList<Customer> models = new PagedList<Customer>(lsCustomers, pageNumber, pageSize);

			ViewBag.CurrentPage = pageNumber;
			return View(models);
		}

		

		// GET: admin/Customer2/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var customer = await _context.Customers
				.FirstOrDefaultAsync(m => m.CustomerId == id);
			if (customer == null)
			{
				return NotFound();
			}

			return View(customer);
		}

		// GET: admin/Customer2/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: admin/Customer2/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("CustomerId,FullName,Birthday,Avatar,Address,Email,Phone,CreateDate,Password,Salt,LastLogin,Active")] Customer customer)
		{
			if (ModelState.IsValid)
			{
				_context.Add(customer);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(customer);
		}

		// GET: admin/Customer2/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var customer = await _context.Customers.FindAsync(id);
			if (customer == null)
			{
				return NotFound();
			}
			return View(customer);
		}

		// POST: admin/Customer2/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FullName,Birthday,Avatar,Address,Email,Phone,CreateDate,Password,Salt,LastLogin,Active")] Customer customer)
		{
			if (id != customer.CustomerId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(customer);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CustomerExists(customer.CustomerId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(customer);
		}

		// GET: admin/Customer2/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var customer = await _context.Customers
				.FirstOrDefaultAsync(m => m.CustomerId == id);
			if (customer == null)
			{
				return NotFound();
			}

			return View(customer);
		}

		// POST: admin/Customer2/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var customer = await _context.Customers.FindAsync(id);
			if (customer != null)
			{
				_context.Customers.Remove(customer);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CustomerExists(int id)
		{
			return _context.Customers.Any(e => e.CustomerId == id);
		}
	}
}

