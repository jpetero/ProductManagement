using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Laptop Bag",
                    Price = 50000,
                    Description = "Best laptop bag ever"  
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Water Bottle",
                    Price = 15000,
                    Description = "Water bottle for life"
                }
                );
        }
    }
}
