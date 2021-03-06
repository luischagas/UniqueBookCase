﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniqueBookCase.Api.Extensions;

namespace UniqueBookCase.Api.ViewModels
{
    public class AuthorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [MinimumAge(30, ErrorMessage = "The field {0} is invalid, minimum age 30 years old.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime DateOfBirth { get; set; }

        [DocumentValidation(ErrorMessage = "The field {0} is invalid.")]
        [Required(ErrorMessage = "The field {0} is required")]
        public string Document { get; set; }
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
