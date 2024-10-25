using LibraryManagementSystem.Data.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Controllers
{
    public class ReturnController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public ReturnController(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult List()
        {
            Func<Book, bool> myFilter = x => x.BorrowerId != 0;

            //Expression<Func<Book, bool>> myFilter = x => x.BorrowerId != 0;

            // Check the books collection
            if (!_bookRepository.Any(myFilter))
            {
                return View("Empty");
            }

            // load all borrowed books
            var borrowedBooks = _bookRepository.FindWithAuthorAndBorrower(myFilter);


            return View(borrowedBooks);
        }

        //public IActionResult ReturnABook(int bookId)
        //{
        //    var book = _bookRepository.GetById(bookId);

        //    book.Borrower = null;

        //    book.BorrowerId = 0;

        //    _bookRepository.Update(book);

        //    return RedirectToAction("List");
        //}


        public IActionResult ReturnABook(int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            if (book == null)
            {
                return NotFound(); // Handle the case where the book is not found
            }

            book.Borrower = null; // Optionally, if you want to clear the Borrower reference
            book.BorrowerId = null; // Set BorrowerId to null instead of 0

            _bookRepository.Update(book);
            return RedirectToAction("List");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
