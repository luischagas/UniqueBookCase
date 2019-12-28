using AutoMapper;
using UniqueBookCase.Api.ViewModels;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.Api.Configuration
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Author, AuthorViewModel>().ReverseMap();
            CreateMap<Book, BookViewModel>().ReverseMap();
        }
    }
}
