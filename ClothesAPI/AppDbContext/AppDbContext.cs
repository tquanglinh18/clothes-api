using System;
using ClothesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothesAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
    }
}

