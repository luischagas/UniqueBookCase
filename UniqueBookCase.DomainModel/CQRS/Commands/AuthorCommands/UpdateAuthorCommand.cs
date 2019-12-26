using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.CQRS.Commands.AuthorCommands
{
    public class UpdateAuthorCommand : AuthorCommand
    {
        public const string ConstQueueName = "update-author-command-queue";
        public override string QueueName => ConstQueueName;

        public UpdateAuthorCommand(Author author) : base(author)
        {
        }

        public override bool isValid()
        {
            ValidationResult = new UpdateAuthorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateAuthorCommandValidation : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidation()
        {
            RuleFor(c => c.Author.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Invalid author id");

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
