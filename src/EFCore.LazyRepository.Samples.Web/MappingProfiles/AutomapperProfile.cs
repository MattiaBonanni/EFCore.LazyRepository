using AutoMapper;
using EFCore.LazyRepository.Samples.Data.Entities;
using EFCore.LazyRepository.Samples.Web.DTOs;

namespace EFCore.LazyRepository.Samples.Web.MappingProfiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            #region EntityToDto

            CreateMap<FooBar, FooBarDto>();

            #endregion

            #region DtoToEntity

            CreateMap<FooBarDto, FooBar>();

            #endregion
        }
    }
}
