using AutoMapper;
using UniqueBookCase.Api.ViewModels;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.CQRS.Commands;

namespace UniqueBookCase.Api.Configuration
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterViewModelDomainMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
            });
        }

    }
}
