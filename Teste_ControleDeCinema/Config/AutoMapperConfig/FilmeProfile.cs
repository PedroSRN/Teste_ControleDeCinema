using AutoMapper;
using System;
using Teste_ControleDeCinema.Dominio.ModuloFilme;
using Teste_ControleDeCinema.Webapi.ViewModels.ModuloFilme;

namespace Teste_ControleDeCinema.Webapi.Config.AutoMapperConfig
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<FormsFilmeViewModel, Filme>()
               .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())
               .ForMember(destino => destino.Id, opt => opt.Ignore());

            CreateMap<Filme, ListarFilmeViewModel>()
                 .ForMember(d => d.Duracao, opt => opt.MapFrom(o => o.Duracao.ToString(@"hh\:mm\:ss")));

            CreateMap<Filme, VisualizarFilmeViewModel>()
               .ForMember(destino => destino.Sessoes, opt => opt.MapFrom(origem => origem.Sessoes));

            CreateMap<Filme, FormsFilmeViewModel>();

        }

    }
}
