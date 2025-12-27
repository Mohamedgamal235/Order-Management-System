namespace Order_Management_System.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();
        Task<ProductResponseDto?> GetProductByIdAsync(Guid id);
        Task<Guid> AddProductAsync(ProductCreateDto dto);
        Task UpdateProductAsync(Guid id, ProductUpdateDto dto);
    }
}
