using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using XenteSDK;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger logger;
        private readonly IConfiguration config;

        public TransactionController(IProductRepository productRepository, UserManager<ApplicationUser> userManager, ILogger<TransactionController> logger, IConfiguration config)
        {
            this._productRepository = productRepository;
            this.userManager = userManager;
            this.logger = logger;
            this.config = config;
        }

        [HttpGet]
        public IActionResult Buy(string id)
        {
            Product product = this._productRepository.GetProduct(id);

            if (product == null)
            {
                Response.StatusCode = 404;
                return View("ProductNotFound", id);
            }

            var user = userManager.GetUserId(HttpContext.User);

            BuyViewModel buyViewModel = new BuyViewModel
            {
                ProductId = product.Id,
                Email = GetCurrentUserAsync().GetAwaiter().GetResult().Email,
                Price = product.Price.ToString(),
                ProductName = product.Name
            };
            return View(buyViewModel);
        }

        [HttpPost]
       public async Task<IActionResult> CreateTransaction(BuyViewModel model)
        {
            //Authenication Credentias
            string apikey = config["ApiKey"];

            string password = config["Password"];

            const string mode = "sandbox"; // "live"


            // Initialize the Xente class
            XentePayment xenteGateWay = new XentePayment(apikey, password, mode);


            // Create the transaction request 

            // Decide which payment provider to select
            string paymentProvider = "MTNMOBILEMONEYUG";
          
            string amount = model.Price;

            string message = $"Payment for {model.ProductName}";

            string customerId = GetCurrentUserAsync().GetAwaiter().GetResult().Id;

            string customerPhone = model.PhoneNumber;

            string customerEmail = model.Email;
             string customerReference = model.PhoneNumber;

            string batchId = "Batch001";

            string requestId = Guid.NewGuid().ToString();

            // This is optional parameter
            string metadata = "extra information about transaction";

            try
            {
                TransactionProcessingResponse transactionProcessingResponse = await xenteGateWay.Transaction.CreateTransaction(
                    paymentProvider, amount, message, customerId, customerPhone, customerEmail, customerReference, batchId, requestId, metadata

                    );

                logger.LogInformation($"Message = {transactionProcessingResponse.Message}");
                logger.LogInformation($"Code = {transactionProcessingResponse.Code}");
                logger.LogInformation($"CorrelationId = {transactionProcessingResponse.CorrelationId}");
                logger.LogInformation($"Data Message = {transactionProcessingResponse.Data.Message}");
                logger.LogInformation($"BatchId = {transactionProcessingResponse.Data.BatchId}");
                logger.LogInformation($"TransactionId = {transactionProcessingResponse.Data.TransactionId}");
                logger.LogInformation($"Created On = {transactionProcessingResponse.Data.CreatedOn}");
                logger.LogInformation($"Request ID = {transactionProcessingResponse.Data.RequestId}");

                logger.LogInformation("{@TransactionProcesingResponse}", transactionProcessingResponse);
                return View("Processing", transactionProcessingResponse);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                logger.LogError(ex.StackTrace);
                return View("Error", new { Message = ex.Message });
            }
        }

        // The Lamba expression return a user when called
        private async Task<ApplicationUser> GetCurrentUserAsync() => await userManager.GetUserAsync(HttpContext.User);

        // The Callback URL
        public void TransactionNotification(TransactionDetailsResponse transactionDetailsResponse)
        {
            // Do something with the transaction details
            // Updating the customer account
            // Logging the information to a file or a database etc.
        }
    }
}
