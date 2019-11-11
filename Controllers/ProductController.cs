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
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger<HomeController> logger;

        public ProductController(IProductRepository productRepository, IHostingEnvironment hostingEnvironment,
            ILogger<HomeController> logger)
        {
            _productRepository = productRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        public ViewResult Index()
        {
            IEnumerable<Product> model = _productRepository.GetAllProducts();
            return View(model);
        }

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

        [HttpGet]
        public ViewResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Product newProduct = new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    PhotoPath = uniqueFileName

                };
                _productRepository.Add(newProduct);
                return RedirectToAction("details", new { id = newProduct.Id });
            }

            return View();

        }

        [HttpGet]
        public ViewResult Edit(string id)
        {
            Product product = _productRepository.GetProduct(id);
            ProductEditViewModel productEditViewModel = new ProductEditViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ExistingPhotoPath = product.PhotoPath
            };
            return View(productEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = _productRepository.GetProduct(model.Id);
                product.Name = model.Name;
                product.Price = model.Price ;
                product.Description = model.Description;

                // Check if an employee has a photo
                if (model.Photo != null)
                {
                    // Delete the previous photo
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    product.PhotoPath = ProcessUploadedFile(model);
                }

                _productRepository.Update(product);
                return RedirectToAction("index");
            }

            return View();

        }


        [HttpPost]
        public IActionResult DeleteProduct(string id)
        {
            Product product = _productRepository.Delete(id);
            return RedirectToAction("Index");
        }

        // This generate a file path and save the photo to a file
        private string ProcessUploadedFile(ProductCreateViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
