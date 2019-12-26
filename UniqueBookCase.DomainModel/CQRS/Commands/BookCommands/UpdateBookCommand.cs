using FluentValidation;
using System;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.CQRS.Commands.BookCommands
{
    public class UpdateBookCommand : BookCommand
    {
        public UpdateBookCommand(Book book) : base(book)
        {
        }

        public override bool isValid()
        {
            ValidationResult = new UpdateBookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateBookCommandValidation : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidation()
        {
            RuleFor(c => c.Book.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Invalid book id");

            RuleFor(b => b.Book.Title)
                .NotEmpty()
                .WithMessage("Title name was not entered");

            RuleFor(c => c.Book.Category)
                .NotEmpty()
                .WithMessage("Book's category was not informed");

            RuleFor(c => c.Book.ISBN)
                .NotEmpty()
                .WithMessage("Book's ISBN was not informed");
        }
    }
}

