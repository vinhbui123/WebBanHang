﻿using Microsoft.AspNetCore.Mvc;

namespace WebBanHang.Areas.admin.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
