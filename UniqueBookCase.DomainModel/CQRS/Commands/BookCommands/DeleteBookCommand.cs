using FluentValidation;
using System;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.CQRS.Commands.BookCommands
{
    public class DeleteBookCommand : BookCommand
    {
        public const string ConstQueueName = "delete-book-command-queue";
        public override string QueueName => ConstQueueName;

        public DeleteBookCommand(Book book) : base(book)
        {
        }

        public override bool isValid()
        {
            ValidationResult = new DeleteBookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class DeleteBookCommandValidation : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidation()
        {
            RuleFor(c => c.Book.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Invalid book id");
   
        }
    }
}

