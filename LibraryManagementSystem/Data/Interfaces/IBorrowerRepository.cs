using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data.Interfaces
{
    public interface IBorrowerRepository
    {
        IEnumerable<Customer> GetAll();
    }



}
