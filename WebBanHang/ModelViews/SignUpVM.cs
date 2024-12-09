using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.ModelViews
{
	public class SignUpVM
	{
		[Key]
		public int CustomerId { get; set; }
		[Display(Name = "Name")]
		[Required(ErrorMessage = "Input Name")]
		public string FullName { get; set; }

		[Required(ErrorMessage = "Input Email")]
		[MaxLength(150)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
		[Remote(action: "ValidateEmail", controller: "Account")]
		public string Email { get; set; }

		[MaxLength(11)]
		[Required(ErrorMessage = "Input Phone Number")]
		[Display(Name = "Phone Number")]
		[DataType(DataType.PhoneNumber)]
		[Remote(action: "ValidatePhone", controller: "Account")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Password")]
		[Required(ErrorMessage = "Input Password")]
		[MinLength(5, ErrorMessage = "input minimum 5 characters")]
		public string Password { get; set; }
		[MinLength(5, ErrorMessage = "input minimum 5 characters")]
		[Display(Name = "Comfirm Password")]
		[Compare("Password", ErrorMessage = "Password isn't same")]
		public string ConfirmPassword { get; set; }
	}
}
