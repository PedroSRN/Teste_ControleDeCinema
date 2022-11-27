using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Dominio.Compartilhado;
using Teste_ControleDeCinema.Dominio.ModuloAutenticacao;
using Teste_ControleDeCinema.Dominio.ModuloSessao;

namespace Teste_ControleDeCinema.Dominio.ModuloFilme
{
    public class Filme : EntidadeBase<Filme>
    {
        public Filme()
        {
                
        }

        public Filme(string titulo, TimeSpan duracao, string descricao)
        {
            Titulo = titulo;
            Duracao = duracao;
            Descricao = descricao;
        }

        public override void Atualizar(Filme registro)
        {
            Id = registro.Id;
            Titulo = registro.Titulo;
            Duracao = registro.Duracao;
            Descricao = registro.Descricao;
        }

        public override bool Equals(object obj)
        {
            return obj is Filme filme &&
                   Id.Equals(filme.Id) &&
                   Titulo == filme.Titulo &&
                   Duracao.Equals(filme.Duracao) &&
                   Descricao == filme.Descricao &&
                   EqualityComparer<List<Sessao>>.Default.Equals(Sessoes, filme.Sessoes);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Titulo, Duracao, Descricao, Sessoes);
        }

        public string  Titulo { get; set; }
        public TimeSpan Duracao { get; set; }
        public string Descricao { get; set; }
        

        public List<Sessao> Sessoes { get; set; }

    }
}
