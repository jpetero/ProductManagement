using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<SQLProductRepository> logger;

        public SQLProductRepository(AppDbContext context, 
            ILogger<SQLProductRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Product Add(Product employee)
        {
            context.Products.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Product Delete(string id)
        {
            Product employee = context.Products.Find(id);
            if (employee != null)
            {
                context.Products.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products;
        }

        public Product GetProduct(string Id)
        {
       
            return context.Products.Find(Id);
        }

        public Product Update(Product employeeChanges)
        {
            var employee = context.Products.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
