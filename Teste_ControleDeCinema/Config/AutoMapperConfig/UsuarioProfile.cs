using AutoMapper;
using Teste_ControleDeCinema.Dominio.ModuloAutenticacao;
using Teste_ControleDeCinema.Webapi.ViewModels.ModuloAutencicacao;

namespace Teste_ControleDeCinema.Webapi.Config.AutoMapperConfig
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RegistrarUsuarioViewModel, Usuario>()
                .ForMember(destino => destino.EmailConfirmed, opt => opt.MapFrom(origem => true))
                .ForMember(destino => destino.UserName, opt => opt.MapFrom(origem => origem.Email));
        }
    }
}
