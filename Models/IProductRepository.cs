using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public interface IProductRepository
    {
        Product GetProduct(string Id);

        IEnumerable<Product> GetAllProducts();

        Product Add(Product employee);

        Product Update(Product employeeChanges);

        Product Delete(string id);

    }
}
