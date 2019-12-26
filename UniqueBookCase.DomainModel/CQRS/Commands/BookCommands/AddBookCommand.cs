using FluentValidation;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.CQRS.Commands.BookCommands
{
    public class AddBookCommand : BookCommand
    {
        public AddBookCommand(Book book) : base(book)
        {
        }

        public override bool isValid()
        {
            ValidationResult = new AddBookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddBookCommandValidation : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidation()
        {
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

