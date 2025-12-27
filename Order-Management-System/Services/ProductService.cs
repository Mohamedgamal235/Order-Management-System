

namespace Order_Management_System.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> AddProductAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity
            };

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return products.Select(p => new ProductResponseDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                StockQuantity = p.StockQuantity
            });
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(Guid id)
        {
            var p = await _unitOfWork.Products.GetByIdAsync(id);
            if (p == null) return null;

            return new ProductResponseDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                StockQuantity = p.StockQuantity
            };
        }

        public async Task UpdateProductAsync(Guid id, ProductUpdateDto dto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id)
                          ?? throw new Exception("Product not found");

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.StockQuantity = dto.StockQuantity;

            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
