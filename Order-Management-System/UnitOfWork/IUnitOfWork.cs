using Order_Management_System.Repositories.Interface;

namespace Order_Management_System.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Customer> Customers { get; }

        Task SaveChangesAsync();
    }
}
