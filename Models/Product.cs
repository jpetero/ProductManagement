using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Product
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Name cannot exceed 50 character")]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string PhotoPath { get; set; }
    }
}
