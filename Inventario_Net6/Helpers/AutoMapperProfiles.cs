using AutoMapper;
using Inventario_Net6.DTOs.Usuario;
using Inventario_Net6.Entidades;

namespace Inventario_Net6.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            //Mapeo de doble vía
            CreateMap<Usuario, UsuarioEditarDTO>().ReverseMap();

        }
    }
}
