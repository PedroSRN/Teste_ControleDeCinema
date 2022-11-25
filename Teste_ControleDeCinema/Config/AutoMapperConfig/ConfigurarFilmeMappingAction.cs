using AutoMapper;
using Teste_ControleDeCinema.Dominio.ModuloFilme;
using Teste_ControleDeCinema.Dominio.ModuloSessao;
using Teste_ControleDeCinema.Webapi.ViewModels.ModuloSessao;

namespace Teste_ControleDeCinema.Webapi.Config.AutoMapperConfig
{
    public class ConfigurarFilmeMappingAction : IMappingAction<FormsSessaoViewModel, Sessao>
    {
        public IRepositorioFilme repositorioFilme;


        public ConfigurarFilmeMappingAction(IRepositorioFilme repositorioFilme)
        {
            this.repositorioFilme = repositorioFilme;
        }


        public void Process(FormsSessaoViewModel sessaoVM, Sessao sessao, ResolutionContext context)
        {
            sessao.Filme = repositorioFilme.SelecionarPorId(sessaoVM.FilmeId);

            sessao.HoraTermino = sessao.HoraInicio + sessao.Filme.Duracao;

            
        }
    }
}
