using LibraryManagementSystem.Data.Interfaces;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {

        public CustomerRepository(ApplicationDbContext context) : base(context) { }

        public override void Delete(Customer entity)
        {
            _context.Books.Where(b => b.Borrower == entity)
                .ToList()
                .ForEach(a =>
                {
                    a.Borrower = null;
                    a.BorrowerId = 0;
                });

            base.Delete(entity);
        }
    }
}
