using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
     
        IEnumerable<Author> GetAllWithBooks();
        Author GetWithBooks(int id);
    }
}
