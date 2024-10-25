using LibraryManagementSystem.Data;
using LibraryManagementSystem.Data.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Controllers
{
    public class LendController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ApplicationDbContext _context;
        public LendController(IBookRepository bookRepository, ICustomerRepository customerRepository,ApplicationDbContext context)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
            _context = context;
        }

        //public IActionResult List()
        //{
        //    Func<Book, bool> myFilter = x => x.BorrowerId == 0;

        //    // check collection
        //    if (!_bookRepository.Any(myFilter))
        //    {
        //        return View("Empty");
        //    }

        //    // load all available books
        //    var availableBooks = _bookRepository.FindWithAuthor(myFilter);

        //    return View(availableBooks);
        //}





        public IActionResult List()
        {
           
            var availableBooks = _context.Books
                           .Include(b => b.Author)  
                           .ToList();
            foreach (var book in availableBooks)
            {
                Console.WriteLine($"BookId: {book.BookId}, Title: {book.Title}, BorrowerId: {book.BorrowerId}, Author: {book.Author?.Name ?? "No Author"}");
            }
           

            if (!availableBooks.Any())
            {
                return View("Empty");
            }


            return View(availableBooks);
        }





        public IActionResult LendBook(int bookId)
        {
            var lendVM = new LendViewModel
            {
                Book = _bookRepository.GetById(bookId),
                Customers = _customerRepository.GetAll()
            };

            return View(lendVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LendBook(LendViewModel lendVM)
        {
            var book = _bookRepository.GetById(lendVM.Book.BookId);

            book.BorrowerId = lendVM.Book.BorrowerId;

            _bookRepository.Update(book);

            return RedirectToAction("List");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
