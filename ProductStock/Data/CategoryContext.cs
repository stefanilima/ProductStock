using System;
using Microsoft.EntityFrameworkCore;
using ProductStock.Models;

namespace ProductStock.Data
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> opt) : base (opt)
        {
        }

        public DbSet<Category> Categorys { get; set; }
    }
}
