using System.ComponentModel.DataAnnotations;

namespace WebBanHang.ModelViews
{
	public class findProduct
	{
		[Key]
		[MaxLength(100)]
		[Required(ErrorMessage = "Input Product")]
		[DataType(DataType.Text)]
		[EmailAddress]
		[Display(Name = "Products")]
		public required string Products { get; set; }

		[Display(Name = "Password")]
		[Required(ErrorMessage = "Input Password")]
		[MinLength(5, ErrorMessage = "input minimum 5 characters")]
		public required string Password { get; set; }
	}
}
