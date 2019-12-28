using FluentValidation;
using System;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.CQRS.Commands.AuthorCommands
{
    public class DeleteAuthorCommand : AuthorCommand
    {
        public const string ConstQueueName = "delete-author-command-queue";
        public override string QueueName => ConstQueueName;

        public DeleteAuthorCommand(Author author) : base(author)
        {
        }

        public override bool isValid()
        {
            ValidationResult = new DeleteAuthorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class DeleteAuthorCommandValidation : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidation()
        {
            RuleFor(c => c.Author.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Invalid author id");
        }
    }
}
    
