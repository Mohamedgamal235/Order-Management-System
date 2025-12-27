
namespace Order_Management_System.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddProductAsync(Product product)
            => await _unitOfWork.Products.AddAsync(product);

        public async Task<IEnumerable<Product>> GetAllProdcts()
            => await _unitOfWork.Products.GetAllAsync();

        public async Task<Product?> GetProductByIdAsync(Guid id)
            => await _unitOfWork.Products.GetByIdAsync(id);

        public async Task UpdateProductAsync(Product product)
            => await _unitOfWork.Products.UpdateAsync(product);
        public async Task SaveChangesAsync()
            => await _unitOfWork.SaveChangesAsync();
    }
}
