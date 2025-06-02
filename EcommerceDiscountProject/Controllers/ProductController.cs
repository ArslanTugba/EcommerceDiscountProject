using EcommerceDiscountProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceDiscountProject.Controllers
{
    
    [ApiController]
  
    [Route("[controller]")]
    public class ProductController : ControllerBase 
    {
        [HttpPost("CalculateDiscount")]
        public IActionResult CalculateDiscount([FromBody] ProductRequest request) 
        {
         
            if (request.OriginalPrice <= 0)
            {     
                return BadRequest("Original price must be greater than 0.");
            }

            if (request.Quantity < 1 || request.Quantity > 100)
            {
             
                return BadRequest("Quantity must be between 1 and 100.");
            }

            try
            {
                decimal categoryDiscountRate = 0;
         
                switch (request.Category?.ToLower()) 
                {
                    case "elektronik":
                        categoryDiscountRate = 0.15m;
                        break;
                    case "giyim":
                        categoryDiscountRate = 0.20m; 
                        break;
                    case "ev & yaşam":
                        categoryDiscountRate = 0.10m; 
                        break;
                    default:
                       
                        break;
                }

                
                decimal categoryDiscount = request.OriginalPrice * categoryDiscountRate;

                decimal priceAfterCategoryDiscount = request.OriginalPrice - categoryDiscount;

                decimal customerDiscountRate = 0;
                
                if (request.CustomerType?.ToLower() == "vip")
                {
                    customerDiscountRate = 0.05m; 
                }
                
                decimal customerDiscount = priceAfterCategoryDiscount * customerDiscountRate;

                decimal quantityDiscountRate = 0;
               
                if (request.Quantity >= 5)
                {
                    quantityDiscountRate = 0.10m;
                }
               
                decimal quantityDiscount = (priceAfterCategoryDiscount - customerDiscount) * quantityDiscountRate;

               
                decimal totalDiscount = categoryDiscount + customerDiscount + quantityDiscount;
                decimal finalPrice = request.OriginalPrice - totalDiscount;

                
                var response = new DiscountResponse
                {
                    ProductName = request.ProductName,
                    OriginalPrice = request.OriginalPrice,
                    CategoryDiscount = categoryDiscount,
                    CustomerDiscount = customerDiscount,
                    QuantityDiscount = quantityDiscount,
                    TotalDiscount = totalDiscount,
                    FinalPrice = finalPrice
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
