using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecureWeb.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(12, ErrorMessage = "Password must be at least 12 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$",
            ErrorMessage = "Password harus mengandung huruf besar, huruf kecil, dan angka.")]
        public string? NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}