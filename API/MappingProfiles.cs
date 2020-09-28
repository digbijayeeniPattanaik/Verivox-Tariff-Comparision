using API.Dto;
using API.Model;
using AutoMapper;

namespace API
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
