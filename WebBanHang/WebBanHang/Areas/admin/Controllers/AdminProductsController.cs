using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PagedList.Core;
using WebBanHang.Helper;
using WebBanHang.Models;

namespace WebBanHang.Areas.admin.Controllers
{
	[Area("admin")]
	public class AdminProductsController : Controller
	{
		private readonly DbNet4Context _context;

		public AdminProductsController(DbNet4Context context)
		{
			_context = context;
		}

		// GET: Admin/AdminProducts
		public IActionResult Index(int page = 1, string Type = "", string Status = "")
		{
			var pageNumber = page;
			var pageSize = 20;

			List<Product> lsProducts = new List<Product>();

			var query = _context.Products.AsNoTracking();

			if (!string.IsNullOrEmpty(Type))
			{
				query = query.Where(x => x.Type == Type);
			}

			if (!string.IsNullOrEmpty(Status))
			{
				if (Status == "instock")
				{
					query = query.Where(x => x.UnitInStock > 0);
				}
				else if (Status == "outofstock")
				{
					query = query.Where(x => x.UnitInStock <= 0);
				}
			}

			lsProducts = query.OrderByDescending(x => x.ProductId).ToList();

			PagedList<Product> models = new PagedList<Product>(lsProducts.AsQueryable(), pageNumber, pageSize);
			ViewBag.CurrentType = Type;
			ViewBag.CurrentStatus = Status; // Thêm ViewBag cho Status
			ViewBag.CurrentPage = pageNumber;

			var types = _context.Products
				.Select(p => p.Type)
				.Distinct()
				.ToList();
			ViewData["DanhMuc"] = new SelectList(types, Type);

			return View(models);
		}

		public IActionResult Filter(string Type = "", string Status = "")
		{
			var url = $"/Admin/AdminProducts?";

			if (!string.IsNullOrEmpty(Type))
			{
				url += $"Type={Type}&";
			}

			if (!string.IsNullOrEmpty(Status))
			{
				url += $"Status={Status}&";
			}

			// Remove trailing '&' if present
			if (url.EndsWith("&"))
			{
				url = url.Substring(0, url.Length - 1);
			}

			if (string.IsNullOrEmpty(Type) && string.IsNullOrEmpty(Status))
			{
				url = "/Admin/AdminProducts"; // Nếu cả hai đều trống, chuyển đến danh sách đầy đủ
			}

			return Json(new { status = "success", redirectUrl = url });
		}

		// GET: admin/AdminProducts/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _context.Products
				

				.FirstOrDefaultAsync(m => m.ProductId == id);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}


		// GET: admin/AdminProducts/Create
		public IActionResult Create()
		{
			ViewData["ProductId"] = new SelectList(_context.ProductDetails, "ProductId", "ProductId");
			var productTypes = _context.Products.Select(p => p.Type).Distinct().ToList(); // Lấy tất cả các loại sản phẩm duy nhất từ bảng Products
			ViewData["DanhMuc"] = new SelectList(productTypes);
			return View();
		}

		// admin/AdminProducts/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		
public async Task<IActionResult> CreateProduct(
    [Bind("ProductId,UnitInStock,Thumb,ProductName,SpecialStatus,Price,PriceDiscounts,Type")] Product product,
    IFormFile fThumb)
{
    if (ModelState.IsValid)
    {
        // Xử lý hình ảnh Thumb
        if (fThumb != null)
        {
            string extension = Path.GetExtension(fThumb.FileName);
            string image = Utilities.SEOUrl(product.ProductName) + extension;
            string imagePath = await Utilities.UploadFile(fThumb, "products", image.ToLower());
            product.Thumb = System.IO.File.ReadAllBytes(imagePath);
        }
        else
        {
             product.Thumb = System.IO.File.ReadAllBytes("wwwroot/images/products/default.jpg");
        }

        // Lưu Product
        _context.Add(product);
        await _context.SaveChangesAsync();

        // Lưu ProductId vào TempData
        TempData["ProductId"] = product.ProductId;

        // Chuyển hướng đến CreateProductDetail
        return RedirectToAction("Create");
    }

    // Nếu ModelState không hợp lệ, load lại danh mục và hiển thị form
    var productTypes = _context.Products.Select(p => p.Type).Distinct().ToList();
    ViewData["DanhMuc"] = new SelectList(productTypes, product.Type); // Giữ lại giá trị đã chọn
    return View(product);
}





		// GET: admin/AdminProducts/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			ViewData["ProductId"] = new SelectList(_context.ProductDetails, "ProductId", "ProductId", product.ProductId);
			var productTypes = _context.Products.Select(p => p.Type).Distinct().ToList(); // Lấy tất cả các loại sản phẩm duy nhất từ bảng Products
			ViewData["DanhMuc"] = new SelectList(productTypes);

			return View(product);
		}

		// POST: admin/AdminProducts/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		async Task<IActionResult> Edit(int id, [Bind("ProductId,TypeId,UnitInStock,Thumb,ProductName,SpecialStatus,Price,PriceDiscounts")] Product product, Microsoft.AspNetCore.Http.IFormFile fThumb)
		{
			
					if (ModelState.IsValid)
					{
						product.ProductName = Utilities.ToTitleCase(product.ProductName);

						if (fThumb != null)
						{
							string extension = Path.GetExtension(fThumb.FileName);
							string image = Utilities.SEOUrl(product.ProductName) + extension;
							string imagePath = await Utilities.UploadFile(fThumb, @"products", image.ToLower());
							product.Thumb = System.IO.File.ReadAllBytes(imagePath);
						}

						if (product.Thumb == null || product.Thumb.Length == 0)
						{
							product.Thumb = System.IO.File.ReadAllBytes("default.jpg");


							_context.Update(product);
							await _context.SaveChangesAsync();
						}


						return RedirectToAction(nameof(Index));
					}
					ViewData["ProductId"] = new SelectList(_context.ProductDetails, "ProductId", "ProductId", product.ProductId);
					var productTypes = _context.Products.Select(p => p.Type).Distinct().ToList();
					ViewData["DanhMuc"] = new SelectList(productTypes);

					return View(product);
				} 

		// GET: admin/AdminProducts/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _context.Products
				
				.Include(p => p.Type)
				.FirstOrDefaultAsync(m => m.ProductId == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// POST: admin/AdminProducts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product != null)
			{
				// Xóa ProductDetail trước
				var productDetail = await _context.ProductDetails.FirstOrDefaultAsync(pd => pd.ProductId == id);
				if (productDetail != null)
				{
					_context.ProductDetails.Remove(productDetail);
				}

				// Xóa Product
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));
		}
	}
	}
