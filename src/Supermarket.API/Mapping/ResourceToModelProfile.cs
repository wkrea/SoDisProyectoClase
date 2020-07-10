using AutoMapper;
using Supermarket.API.Dominio.Recursos;
using Supermarket.API.Dominio.Entidades;

namespace Supermarket.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoriaRecurso, Categoria>();

            CreateMap<SaveProductoRecurso, Producto>()
                .ForMember(src => src.unidadDMedida, opt => opt.MapFrom(src => (EUndMedida)src.unidadDMedida));
        }
    }
}