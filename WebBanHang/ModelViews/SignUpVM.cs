using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.ModelViews
{
	public class SignUpVM
	{
		public int CustomerId { get; set; }
		[Display(Name = "Họ và tên")]
		[Required(ErrorMessage = "Vui lòng nhập Họ tên")]
		public required string CustomerName { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập Email")]
		[MaxLength(150)]
		[DataType(DataType.EmailAddress)]
		[Remote(action: "validateEmail", controller: "Account")]
		public required string Email { get; set; }

		[MaxLength(11)]
		[Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
		[DataType(DataType.PhoneNumber)]
		[Remote(action: "validatePhone", controller: "Account")]
		public required string PhoneNumber { get; set; }

		[Display(Name = "Mật khẩu")]
		[Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
		[MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu 5 kí tự")]
		public required string Password { get; set; }


	}
}
