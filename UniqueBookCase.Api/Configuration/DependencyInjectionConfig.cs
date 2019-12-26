using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UniqueBookCase.DomainModel.CQRS.Commands;
using UniqueBookCase.DomainModel.CQRS.Commands.AuthorCommands;
using UniqueBookCase.DomainModel.CQRS.Commands.BookCommands;
using UniqueBookCase.DomainModel.CQRS.Communication.Mediator;
using UniqueBookCase.DomainModel.Interfaces.CQRS;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.DomainModel.Interfaces.Services;
using UniqueBookCase.DomainModel.Interfaces.UoW;
using UniqueBookCase.DomainService;
using UniqueBookCase.Infra.Context;
using UniqueBookCase.Infra.CQRS;
using UniqueBookCase.Infra.Repository;
using UniqueBookCase.Infra.UoW;

namespace UniqueBookCase.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<UniqueBookCaseContext>();
            services.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork>();
            services.AddScoped<IQueue, RabbitMQueue>();

            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Author
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorCommands, AuthorCommands>();
            services.AddScoped<IAuthorQueries, AuthorQueries>();
            services.AddScoped<IRequestHandler<AddAuthorCommand, bool>, AuthorCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAuthorCommand, bool>, AuthorCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteAuthorCommand, bool>, AuthorCommandHandler>();

            //Book
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookCommands, BookCommands>();
            services.AddScoped<IBookQueries, BookQueries>();
            services.AddScoped<IRequestHandler<AddBookCommand, bool>, BookCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateBookCommand, bool>, BookCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteBookCommand, bool>, BookCommandHandler>();

            return services;
        }
    }
}

