using LibraryManagementSystem.Data.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Book> FindWithAuthor(Expression<Func<Book, bool>> predicate)
        {
            return _context.Books
                .Include(a => a.Author)
                .Where(predicate).ToList();

        }






        //public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate)
        //{
        //    return _context.Books
        //       .Include(b => b.Author)
        //       .Include(b => b.Borrower)
        //       .Where(predicate);
        //}

        //public IEnumerable<Book> GetAllWithAuthor()
        //{
        //    return _context.Books.Include(a => a.Author);
        //}



        //public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate)
        //{
        //    // Load all books with authors
        //    var booksWithAuthors = _context.Books.Include(b => b.Author).ToList();

        //    // Apply the predicate (filter) in memory
        //    return booksWithAuthors.Where(predicate).ToList();
        //}

        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate)
        {
          
            var booksWithAuthorAndBorrower = _context.Books
                                                      .Include(b => b.Author)
                                                      .Include(b => b.Borrower)
                                                      .ToList();

           
            return booksWithAuthorAndBorrower.Where(predicate).ToList();
        }



        public IEnumerable<Book> GetAllWithAuthor()
        {
             return _context.Books.Include(b => b.Author).ToList();
            
        }




    }
}
