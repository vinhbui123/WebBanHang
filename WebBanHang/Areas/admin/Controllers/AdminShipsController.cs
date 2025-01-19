using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Model;

namespace WebBanHang.Areas.admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminShipsController : Controller
    {
        private readonly WebBanHangContext _context;

        public AdminShipsController(WebBanHangContext context)
        {
            _context = context;
        }

        // GET: admin/AdminShips
        public async Task<IActionResult> Index()
        {
            var WebBanHangContext = _context.Ships.Include(s => s.Shipper);
            return View(await WebBanHangContext.ToListAsync());
        }

        // GET: admin/AdminShips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships
                .Include(s => s.Shipper)
                .FirstOrDefaultAsync(m => m.ShipId == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // GET: admin/AdminShips/Create
        public IActionResult Create()
        {
            ViewData["ShipperId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            return View();
        }

        // POST: admin/AdminShips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ShipId,ShipperId,ShippingAddresses,ExpectedDeliveryDate,ShipStatus")] Ship ship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShipperId"] = new SelectList(_context.Orders, "OrderId", "OrderId", ship.ShipperId);
            return View(ship);
        }

        // GET: admin/AdminShips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships.FindAsync(id);
            if (ship == null)
            {
                return NotFound();
            }
            ViewData["ShipperId"] = new SelectList(_context.Orders, "OrderId", "OrderId", ship.ShipperId);
            return View(ship);
        }

        // POST: admin/AdminShips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ShipId,ShipperId,ShippingAddresses,ExpectedDeliveryDate,ShipStatus")] Ship ship)
        {
            if (id != ship.ShipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipExists(ship.ShipId))
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
            ViewData["ShipperId"] = new SelectList(_context.Orders, "OrderId", "OrderId", ship.ShipperId);
            return View(ship);
        }

        // GET: admin/AdminShips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships
                .Include(s => s.Shipper)
                .FirstOrDefaultAsync(m => m.ShipId == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // POST: admin/AdminShips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ship = await _context.Ships.FindAsync(id);
            if (ship != null)
            {
                _context.Ships.Remove(ship);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipExists(int id)
        {
            return _context.Ships.Any(e => e.ShipId == id);
        }
    }
}
