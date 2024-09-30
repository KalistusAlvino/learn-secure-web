using System;
using System.ComponentModel.DataAnnotations;

namespace SecureWeb.Models
{
    public class Mahasiswa
    {
        [Key]
        public int Nim { get; set; }
        public string Nama { get; set; } = null!;
        public string Alamat { get; set; } = null!;
    }
}