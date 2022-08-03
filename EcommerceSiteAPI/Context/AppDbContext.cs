using EcommerceSiteAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcommerceSiteAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
