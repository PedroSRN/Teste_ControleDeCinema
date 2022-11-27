using AutoMapper;
using Teste_ControleDeCinema.Dominio.ModuloSala;
using Teste_ControleDeCinema.Webapi.ViewModels.ModuloSala;

namespace Teste_ControleDeCinema.Webapi.Config.AutoMapperConfig
{
    public class SalaProfile : Profile
    {
        public SalaProfile()
        {
            CreateMap<FormsSalaViewModel, Sala>()
               .ForMember(destino => destino.Id, opt => opt.Ignore());


            CreateMap<Sala, ListarSalaViewModel>();

            CreateMap<Sala, VisualizarSalaViewModel>()
              .ForMember(destino => destino.Sessoes, opt => opt.MapFrom(origem => origem.Sessoes));

            CreateMap<Sala, FormsSalaViewModel>();
        }
    }
}
