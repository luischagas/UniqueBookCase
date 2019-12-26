using FluentValidation;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.CQRS.Commands.AuthorCommands
{
    public class AddAuthorCommand : AuthorCommand
    {
        public const string ConstQueueName = "add-author-command-queue";
        public override string QueueName => ConstQueueName;

        public AddAuthorCommand(Author author) : base(author)
        {
        }

        public override bool isValid()
        {
            ValidationResult = new AddAuthorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddAuthorCommandValidation : AbstractValidator<AddAuthorCommand>
    {
        public AddAuthorCommandValidation()
        {
            RuleFor(c => c.Author.Name)
                .NotEmpty()
                .WithMessage("Author name was not entered");

            RuleFor(c => c.Author.DateOfBirth)
                .NotEmpty()
                .WithMessage("Author's date of birth was not informed");

            RuleFor(c => c.Author.Document)
                .NotEmpty()
                .WithMessage("Author's document was not informed");       
        }
    }
}
