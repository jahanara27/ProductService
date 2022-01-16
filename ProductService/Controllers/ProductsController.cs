using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private Product _product;
        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
            _product = new Product();
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(0, 5);
                bool shouldThrowError = randomNumber <= 0.2;
                if (shouldThrowError)
                {
                    throw new Exception("An unknown error occurred");
                }
                var response = await _product.GetProductsAsync();
                var products = response.Select(item => new {
                    Id = item.Id,
                    Brand = item.Brand,
                    Model = item.Model,
                }).ToList();
                Thread.Sleep((int)(rnd.Next(0,5) * 2000));                
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = (await _product.GetProductsAsync()).Where(x => x.Id == id).FirstOrDefault();
                if (product == null)
                    return NotFound();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}