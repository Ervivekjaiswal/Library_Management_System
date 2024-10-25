using LibraryManagementSystem.Models;
namespace LibraryManagementSystem.ViewModels
{
    public class LendViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

    }
}
