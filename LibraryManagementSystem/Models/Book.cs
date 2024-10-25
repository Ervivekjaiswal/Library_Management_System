using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Author field is required.")]
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }

        [Required(ErrorMessage = "The Borrower field is required.")]
        public int? BorrowerId { get; set; }

        public virtual Customer? Borrower { get; set; }
    }

}
