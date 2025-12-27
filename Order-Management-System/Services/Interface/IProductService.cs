namespace Order_Management_System.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProdcts();
        Task<Product?> GetProductByIdAsync(Guid id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task SaveChangesAsync();
    }
}
