using AutoMapper;
using Teste_ControleDeCinema.Dominio.ModuloSessao;
using Teste_ControleDeCinema.Webapi.ViewModels.ModuloSessao;

namespace Teste_ControleDeCinema.Webapi.Config.AutoMapperConfig
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<FormsSessaoViewModel, Sessao>()
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())
                .ForMember(destino => destino.Id, opt => opt.Ignore());

            CreateMap<Sessao, ListarSessaoViewModel>()
                .ForMember(d => d.Data, opt => opt.MapFrom(o => o.Data.ToShortDateString()))
                .ForMember(d => d.HoraInicio, opt => opt.MapFrom(o => o.HoraInicio.ToString(@"hh\:mm\:ss")))
                .ForMember(d => d.HoraTermino, opt => opt.MapFrom(o => o.HoraTermino.ToString(@"hh\:mm\:ss")))
                .ForMember(d => d.NomeFilme, opt => opt.MapFrom(o => o.Filme.Titulo))
                .ForMember(d => d.NomeSala, opt => opt.MapFrom(o => o.Sala.Nome))
                .ForMember(d => d.ValorIngresso, opt => opt.MapFrom(o => o.ValorIngresso)); 

            CreateMap<Sessao, VisualizarSessaoViewModel>();


            CreateMap<Sessao, FormsSessaoViewModel>();
        }
    }
}
