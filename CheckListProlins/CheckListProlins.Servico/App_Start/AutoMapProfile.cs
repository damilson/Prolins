using AutoMapper;
using SIPE.Repositorio.Model;
using SIPE.Servico.DTO;

namespace SIPE.Servico
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Logradouro, LogradouroDTO>().ReverseMap();
        }
    }
}