using System;
using System.ComponentModel.DataAnnotations;
using UniqueBookCase.Api.Extensions;

namespace UniqueBookCase.Api.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        [UniqueIdentificator(ErrorMessage = "The field {0} is invalid.")]
        [Required(ErrorMessage = "The field {0} is required")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Category { get; set; }
        public AuthorViewModel Author { get; set; }

    }
}
