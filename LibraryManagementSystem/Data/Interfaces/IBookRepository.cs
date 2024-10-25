using LibraryManagementSystem.Models;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Data.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllWithAuthor();
       // IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate);
        IEnumerable<Book> FindWithAuthor(Expression<Func<Book, bool>> predicate);
       IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate);


       // IEnumerable<Book> FindWithAuthorAndBorrower(Expression<Func<Book, bool>> predicate);
    }
}
