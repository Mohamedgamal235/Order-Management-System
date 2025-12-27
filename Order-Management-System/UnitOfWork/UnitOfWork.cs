using Order_Management_System.Context;
using Order_Management_System.Repositories;
using Order_Management_System.Repositories.Interface;

namespace Order_Management_System.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementSystemContext _context;
        public IGenericRepository<Order> Orders { get; }
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<Customer> Customers { get; }
        public IGenericRepository<Invoice> Invoices { get; }

        public UnitOfWork(OrderManagementSystemContext context)
        {
            _context = context;
            Orders = new GenericRepository<Order>(_context);
            Products = new GenericRepository<Product>(_context);
            Customers = new GenericRepository<Customer>(_context);
            Invoices = new GenericRepository<Invoice>(_context);
        }

        public void Dispose()
            => _context.Dispose();

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
