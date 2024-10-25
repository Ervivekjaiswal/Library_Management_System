using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.ViewModels
{
    public class BookEditViewModel
    {
        public Book Book { get; set; }

        public IEnumerable<Author>? Authors { get; set; }
        public IEnumerable<Customer>? Borrowers { get; set; }
    }
}
