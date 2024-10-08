using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecureWeb.Models;

namespace SecureWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Mahasiswa> Mahasiswas { get; set;} = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}