using LibraryManagementSystem.Data.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBorrowerRepository _borrowerRepository;



        public BookController(IBookRepository repository, IAuthorRepository authorRepository,IBorrowerRepository borrowerRepository)
        {
            _repository = repository;
            _authorRepository = authorRepository;
            _borrowerRepository = borrowerRepository;
        }

        [Route("Book")]
        public IActionResult List(int? authorId, int? borrowerId)
        {
            IEnumerable<Book> books;
            ViewBag.AuthorId = authorId;

            if (borrowerId != null)
            {
                books = _repository.FindWithAuthorAndBorrower(x => x.BorrowerId == borrowerId);
                return CheckBooksCount(books);
            }

            books = authorId == null
                ? _repository.GetAllWithAuthor()
                : _repository.FindWithAuthor(a => a.Author.AuthorId == authorId);

            if (authorId != null)
            {
                var author = _authorRepository.GetWithBooks((int)authorId);
                if (author.Books == null || !author.Books.Any())
                    return View("EmptyAuthor", author);
            }

            return CheckBooksCount(books);
        }

        private IActionResult CheckBooksCount(IEnumerable<Book> books)
        {
            if (books == null || !books.Any())
            {
                return View("Empty");
            }
            return View(books);
        }

        //public IActionResult Update(int id)
        //{
        //    var book = _repository.FindWithAuthor(a => a.BookId == id).FirstOrDefault();
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    var bookVM = new BookEditViewModel
        //    {
        //        Book = book,
        //        Authors = _authorRepository.GetAll()

        //    };

        //    return View(bookVM);
        //}

        public IActionResult Update(int id)
        {
            var book = _repository.FindWithAuthor(a => a.BookId == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            var bookVM = new BookEditViewModel
            {
                Book = book,
                Authors = _authorRepository.GetAll(),
                Borrowers = _borrowerRepository.GetAll()
            };

            return View(bookVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(BookEditViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                bookVM.Borrowers = _borrowerRepository.GetAll();
                //bookVM.Authors = _authorRepository.GetAll();
                return View(bookVM);
            }

            _repository.Update(bookVM.Book);
            return RedirectToAction("List");
        }

        public IActionResult Create(int? authorId)
        {
            var book = new Book
            {
                AuthorId = authorId ?? 0 
            };

            var bookVM = new BookEditViewModel
            {
                Authors = _authorRepository.GetAll(),
                //Borrowers = (IEnumerable<Customer>)_authorRepository.GetAll(),
                Borrowers = _borrowerRepository.GetAll(),
                Book = book
            };

            return View(bookVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookEditViewModel bookVM)
        {
            //if (bookVM.Book.BorrowerId == 0)
            //{
            //    ModelState.AddModelError("Book.BorrowerId", "The Borrower field is required.");
            //}

            //if (bookVM.Book.AuthorId == 0)
            //{
            //    ModelState.AddModelError("Book.AuthorId", "The Author field is required.");
            //}

            if (ModelState.IsValid)
            {
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                //foreach (var error in errors)
                //{
                //    Console.WriteLine(error.ErrorMessage); 
                //}

                bookVM.Authors = _authorRepository.GetAll();
                bookVM.Borrowers = _borrowerRepository.GetAll();
                return View(bookVM);
            }
           
            _repository.Create(bookVM.Book);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id, int? authorId)
        {
            var book = _repository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            _repository.Delete(book);
            return RedirectToAction("List", new { authorId });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
