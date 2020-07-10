using AutoMapper;
using Supermarket.API.Dominio.Recursos;
using Supermarket.API.Dominio.Entidades;
using Supermarket.API.Extensions;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Categoria, CategoriaRecurso>();

            CreateMap<Producto, ProductoRecurso>()
                .ForMember(src => src.unidadDMedida,
                           opt => opt.MapFrom(src => src.unidadDMedida.ToDescriptionString()));
        }
    }
}