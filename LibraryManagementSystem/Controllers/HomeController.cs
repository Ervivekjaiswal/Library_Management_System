using LibraryManagementSystem.Data.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(IBookRepository bookRepository, IAuthorRepository authorRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var homeVM = new HomeViewModel
            {
                CustomersCount = _customerRepository.Count(x => true),
                AuthorsCount = _authorRepository.Count(x => true),
                BooksCount = _bookRepository.Count(x => true),
                LendedBooksCount = _bookRepository.Count(x => x.BorrowerId != null)
            };

            return View(homeVM);
        }

    }
}
