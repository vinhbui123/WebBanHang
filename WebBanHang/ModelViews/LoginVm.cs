using System.ComponentModel.DataAnnotations;

namespace WebBanHang.ModelViews
{
	public class LoginVm
	{
		[MaxLength(100)]
		[Required(ErrorMessage ="Input Email")]
		[Display(Name = "Email")]
		public required string UserName { get; set; }

		[Display(Name = "Password")]
		[Required(ErrorMessage = "Input Password")]
		[MinLength(5, ErrorMessage = "input minimum 5 characters")]
		public required string Password { get; set; }
	}
}
