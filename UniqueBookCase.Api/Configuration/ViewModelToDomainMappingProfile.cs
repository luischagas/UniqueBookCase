using AutoMapper;
using UniqueBookCase.Api.ViewModels;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.CQRS.Commands.AuthorCommands;
using UniqueBookCase.DomainModel.CQRS.Commands.BookCommands;

namespace UniqueBookCase.Api.Configuration
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            var dtoConfig = AutoMapperConfig.RegisterViewModelDomainMappings();
            var mapper = dtoConfig.CreateMapper();

            //Author
            CreateMap<AuthorViewModel, AddAuthorCommand>()
               .ConstructUsing(a => new AddAuthorCommand(mapper.Map<AuthorViewModel, Author>(a)));

            CreateMap<AuthorViewModel, UpdateAuthorCommand>()
              .ConstructUsing(a => new UpdateAuthorCommand(mapper.Map<AuthorViewModel, Author>(a)));

            CreateMap<AuthorViewModel, DeleteAuthorCommand>()
              .ConstructUsing(a => new DeleteAuthorCommand(mapper.Map<AuthorViewModel, Author>(a)));

            //Book

            CreateMap<BookViewModel, AddBookCommand>()
               .ConstructUsing(a => new AddBookCommand(mapper.Map<BookViewModel, Book>(a)));

            CreateMap<BookViewModel, UpdateBookCommand>()
              .ConstructUsing(a => new UpdateBookCommand(mapper.Map<BookViewModel, Book>(a)));

            CreateMap<BookViewModel, DeleteBookCommand>()
              .ConstructUsing(a => new DeleteBookCommand(mapper.Map<BookViewModel, Book>(a)));
        }
    }
}
