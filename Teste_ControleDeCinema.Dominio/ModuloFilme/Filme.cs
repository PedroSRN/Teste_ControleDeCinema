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

        public Filme(string titulo, TimeSpan duracao, string descricao, string urlImagem)
        {
            Titulo = titulo;
            Duracao = duracao;
            Descricao = descricao;
            UrlImagem = urlImagem;
        }

        public override void Atualizar(Filme registro)
        {
            Id = registro.Id;
            Titulo = registro.Titulo;
            Duracao = registro.Duracao;
            Descricao = registro.Descricao;
            UrlImagem = registro.UrlImagem;
        }

        public override bool Equals(object obj)
        {
            return obj is Filme filme &&
                   Id.Equals(filme.Id) &&
                   UsuarioId.Equals(filme.UsuarioId) &&
                   EqualityComparer<Usuario>.Default.Equals(Usuario, filme.Usuario) &&
                   Titulo == filme.Titulo &&
                   Duracao.Equals(filme.Duracao) &&
                   Descricao == filme.Descricao &&
                   UrlImagem == filme.UrlImagem &&
                   EqualityComparer<List<Sessao>>.Default.Equals(Sessoes, filme.Sessoes);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, UsuarioId, Usuario, Titulo, Duracao, Descricao, UrlImagem, Sessoes);
        }

        public string  Titulo { get; set; }
        public TimeSpan Duracao { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        

        public List<Sessao> Sessoes { get; set; }

    }
}
