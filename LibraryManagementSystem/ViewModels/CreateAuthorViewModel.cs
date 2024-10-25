using LibraryManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.ViewModels
{
    public class CreateAuthorViewModel
    {

        [Required]
        public Author Author { get; set; }
        public string Referer { get; set; }


    }
}
