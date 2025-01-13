using System.Text.RegularExpressions;

namespace WebBanHang.Helper
{
	public static class Utilities
	{
		public static void CreateIfMissing(string path)
		{
			bool folderExists = Directory.Exists(path);
			if (!folderExists)
				Directory.CreateDirectory(path);
		}
		public static string ToTitleCase(string str)
		{
			string result = str;
			if (!string.IsNullOrEmpty(str))
			{
				var words = str.Split(' ');
				for (int index = 0; index < words.Length; index++)
				{
					var s = words[index];
					if (s.Length > 0)
					{
						words[index] = s[0].ToString().ToUpper() + s.Substring(1);
					}
				}
				result = string.Join(" ", words);
			}
			return result;
		}
		public static string SEOUrl(string url)
		{
			url = url.ToLower();
			url = Regex.Replace(url, @"[áàạảãâấầậẩẫăắằặẳẵ]", "a");
			url = Regex.Replace(url, @"[éèẹẻẽêếềệểễ]", "e");
			url = Regex.Replace(url, @"[óòọỏõôốồộổỗơớờợởỡ]", "o");
			url = Regex.Replace(url, @"[íìịỉĩ]", "i");
			url = Regex.Replace(url, @"[ýỳỵỉỹ]", "y");
			url = Regex.Replace(url, @"[úùụủũưứừựửữ]", "u");
			url = Regex.Replace(url, @"[đ]", "d");

			//2. Chỉ cho phép nhận:[0-9a-z-\s]
			url = Regex.Replace(url.Trim(), @"[^0-9a-z-\s]", "").Trim();
			//xử lý nhiều hơn 1 khoảng trắng --> 1 kt
			url = Regex.Replace(url.Trim(), @"\s+", "-");
			//thay khoảng trắng bằng -
			url = Regex.Replace(url, @"\s", "-");
			while (true)
			{
				if (url.IndexOf("--") != -1)
				{
					url = url.Replace("--", "-");
				}
				else
				{
					break;
				}
			}
			return url;
		}
		public static async Task<string> UploadFile(IFormFile file, string sDirectory, string newname = null)
		{
			try
			{
				if (newname == null) newname = file.FileName;

				// Xây dựng đường dẫn thư mục
				string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", sDirectory);
				CreateIfMissing(path);

				// Xây dựng đường dẫn file
				string pathFile = Path.Combine(path, newname);

				// Kiểm tra định dạng file
				var supportedTypes = new[] { "jpg", "jpeg", "png", "gif" };
				var fileExt = Path.GetExtension(file.FileName).Substring(1);
				if (!supportedTypes.Contains(fileExt.ToLower())) // Nếu file không hợp lệ
				{
					return null;
				}

				// Ghi file lên server
				using (var stream = new FileStream(pathFile, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				// Trả về đường dẫn đầy đủ
				return pathFile;
			}
			catch
			{
				return null;
			}
		}
	}

	}
