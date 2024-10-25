using LibraryManagementSystem.Data.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data.Repository
{
    public class BorrowerRepository : Repository<Customer>, IBorrowerRepository

    {
        private readonly ApplicationDbContext _context;
        public BorrowerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList() ?? new List<Customer>();
        }

        public IEnumerable<Customer> GetAllBorrowers()
        {
            return _context.Customers.ToList(); // Returns a list of all customers
        }

        // Get borrower by ID
        public Customer GetBorrowerById(int borrowerId)
        {
            return _context.Customers.FirstOrDefault(b => b.CustomerId == borrowerId);
        }

        // Add new borrower
        public void AddBorrower(Customer borrower)
        {
            _context.Customers.Add(borrower);
            _context.SaveChanges();
        }

        // Update existing borrower
        public void UpdateBorrower(Customer borrower)
        {
            _context.Entry(borrower).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Delete borrower
        public void DeleteBorrower(int borrowerId)
        {
            var borrower = _context.Customers.FirstOrDefault(b => b.CustomerId == borrowerId);
            if (borrower != null)
            {
                _context.Customers.Remove(borrower);
                _context.SaveChanges();
            }
        }

        // Find borrowers by a condition (e.g., name)
        public IEnumerable<Customer> FindBorrowersByCondition(Func<Customer, bool> predicate)
        {
            return _context.Customers.Where(predicate).ToList();
        }


    }
}
