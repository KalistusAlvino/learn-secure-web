using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecureWeb.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; } 
        public bool EmailConfirmed { get; set; }
    }
}