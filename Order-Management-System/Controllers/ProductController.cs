using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Management_System.DTO;

namespace Order_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProdcts();
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();
            
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDetails products)
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                Name = products.Name,
                Price = products.Price,
                StockQuantity = products.StockQuantity
            };

            await _productService.AddProductAsync(product);
            await _productService.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById) , new {id = product.ProductId }, product);
        }
    }
}
