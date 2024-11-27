using System.ComponentModel.DataAnnotations;

namespace WebBanHang.ModelViews
{
	public class LoginVM
	{
		[MaxLength(100)]
		[Required(ErrorMessage = "Vui lòng nhập số điện thoại hoặc email")]
		[Display(Name = "Điện thoại/email")]
		public required string Username { get; set; }

		[Display(Name = "Mật khẩu")]
		[Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
		[MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu 5 kí tự")]
		public required string Password { get; set; }
	}
}
