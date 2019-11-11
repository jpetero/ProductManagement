using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class HomeController: Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger<HomeController> logger;

        public HomeController(IProductRepository productRepository, IHostingEnvironment hostingEnvironment,
            ILogger<HomeController> logger)
        {
            _productRepository = productRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public ViewResult Index()
        {
            IEnumerable<Product> model = _productRepository.GetAllProducts();
            return View(model);
        }

        [AllowAnonymous]
        public ViewResult Details(string id)
        {
            Product product = _productRepository.GetProduct(id);

            if (product == null)
            {
                Response.StatusCode = 404;
                return View("ProductNotFound", id);
            }

            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel
            {
                Product = product,
                PageTitle = "Product Details"
            };
            return View(productDetailsViewModel);
        }
    }
}
