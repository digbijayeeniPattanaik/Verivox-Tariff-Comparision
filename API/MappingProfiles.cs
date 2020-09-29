using API.Model;
using API.Products;
using AutoMapper;

namespace API
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductA, Product>();
            CreateMap<ProductB, Product>();
        }
    }
}
