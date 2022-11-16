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

        public Filme(string titulo, TimeSpan duracao, string descricao, byte[] imagem)
        {
            Titulo = titulo;
            Duracao = duracao;
            Descricao = descricao;
            Imagem = imagem;
        }

        public override void Atualizar(Filme registro)
        {
            Id = registro.Id;
            Titulo = registro.Titulo;
            Duracao = registro.Duracao;
            Descricao = registro.Descricao;
            Imagem = registro.Imagem;
        }

        public string  Titulo { get; set; }
        public TimeSpan Duracao { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }

        public List<Sessao> Sessoes { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Filme filme &&
                   Id.Equals(filme.Id) &&
                   UsuarioId.Equals(filme.UsuarioId) &&
                   EqualityComparer<Usuario>.Default.Equals(Usuario, filme.Usuario) &&
                   Titulo == filme.Titulo &&
                   Duracao == filme.Duracao &&
                   Descricao == filme.Descricao &&
                   EqualityComparer<byte[]>.Default.Equals(Imagem, filme.Imagem);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(UsuarioId);
            hash.Add(Titulo);
            hash.Add(Duracao);
            hash.Add(Descricao);
            hash.Add(Imagem);

            return hash.ToHashCode();   
        }

        
        //public override string ToString()
        //{
        //    return this.Titulo;
        //}
    }
}
