using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Helper;
using WebBanHang.Models;

namespace WebBanHang.Areas.admin.Controllers
{
    [Area("admin")]
    public class AdminProductDetailsController : Controller
    {
        private readonly DbNet4Context _context;

        public AdminProductDetailsController(DbNet4Context context)
        {
            _context = context;
        }

        // GET: admin/AdminProductDetails
        public async Task<IActionResult> Index()
        {
            var dbNet4Context = _context.ProductDetails.Include(p => p.Product);
            return View(await dbNet4Context.ToListAsync());
        }

        // GET: admin/AdminProductDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetails
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }

        // GET: admin/AdminProductDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

		// POST: admin/AdminProductDetails/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductDetail productDetail, IFormFile fImage1, IFormFile fImage2)
		{
			if (ModelState.IsValid)
			{
				// Xử lý hình ảnh cho Images1 (nếu có)
				if (fImage1 != null)
				{
					string extension = Path.GetExtension(fImage1.FileName);
					string image1 = Utilities.SEOUrl("image1-" + productDetail.ProductId) + extension;
					string imagePath1 = await Utilities.UploadFile(fImage1, "products", image1);
					productDetail.Images1 = image1;
				}

				// Xử lý hình ảnh cho Images2 (nếu có)
				if (fImage2 != null)
				{
					string extension = Path.GetExtension(fImage2.FileName);
					string image2 = Utilities.SEOUrl("image2-" + productDetail.ProductId) + extension;
					string imagePath2 = await Utilities.UploadFile(fImage2, "products", image2);
					productDetail.Images2 = image2;
				}

				_context.Add(productDetail);
				await _context.SaveChangesAsync();

				TempData["SuccessMessage"] = "Thêm chi tiết sản phẩm thành công.";

				// Chuyển hướng đến Index hoặc Details của ProductDetail
				return RedirectToAction(nameof(Index));
			}

			// Nếu ModelState không hợp lệ, load lại danh sách sản phẩm và hiển thị form
			ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", productDetail.ProductId);
			return View(productDetail);
		}

		// GET: admin/AdminProductDetails/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", productDetail.ProductId);
            return View(productDetail);
        }

        // POST: admin/AdminProductDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Images1,Color,Brand,Model,ModelYear,Description,Images2")] ProductDetail productDetail)
        {
            if (id != productDetail.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDetailExists(productDetail.ProductId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", productDetail.ProductId);
            return View(productDetail);
        }

        // GET: admin/AdminProductDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetails
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }

        // POST: admin/AdminProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);
            if (productDetail != null)
            {
                _context.ProductDetails.Remove(productDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDetailExists(int id)
        {
            return _context.ProductDetails.Any(e => e.ProductId == id);
        }
    }
}
