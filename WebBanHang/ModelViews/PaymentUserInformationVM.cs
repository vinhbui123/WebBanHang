using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.ModelViews
{
    public class PaymentUserInformationVM
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Input Name")]
        [Remote(action: "ValidateName", controller: "Account")]
        public string FullName { get; set; }

        [MaxLength(11)]
        [Required(ErrorMessage = "Input Phone Number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Remote(action: "ValidatePhone", controller: "Account")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Input your address")]
        [MaxLength(250, ErrorMessage = "Address cannot exceed 250 characters")]
        public string Address { get; set; }

    }
}
