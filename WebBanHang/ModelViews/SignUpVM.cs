using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.ModelViews
{
    public class SignUpVM
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Input Name")]
        [Remote(action: "ValidateName", controller: "Account")]
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
        [MinLength(5, ErrorMessage = "Input minimum 5 characters")]
        public string Password { get; set; }

        [MinLength(5, ErrorMessage = "Input minimum 5 characters")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Birthday")]
        [Required(ErrorMessage = "Input your birthday")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2100", ErrorMessage = "Enter a valid date")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Input your address")]
        [MaxLength(250, ErrorMessage = "Address cannot exceed 250 characters")]
        public string Address { get; set; }
    }
}
