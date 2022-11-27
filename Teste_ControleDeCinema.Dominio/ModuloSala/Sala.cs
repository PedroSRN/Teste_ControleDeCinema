using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Dominio.Compartilhado;
using Teste_ControleDeCinema.Dominio.ModuloAutenticacao;
using Teste_ControleDeCinema.Dominio.ModuloSessao;

namespace Teste_ControleDeCinema.Dominio.ModuloSala
{
    public class Sala : EntidadeBase<Sala>
    {
        public Sala()
        {

        }

        public Sala(string nome, int capacidade)
        {
            Nome = nome;
            Capacidade = capacidade;
        }

        public string Nome  { get; set; }
        public int Capacidade { get; set; }
         public List<Sessao> Sessoes { get; set; }

        public override void Atualizar(Sala registro)
        {
            Id = registro.Id;
            Nome = registro.Nome;
            Capacidade = registro.Capacidade;
        }

        public override bool Equals(object obj)
        {
            return obj is Sala sala &&
                   Id.Equals(sala.Id) &&
                   Nome == sala.Nome &&
                   Capacidade == sala.Capacidade &&
                   EqualityComparer<List<Sessao>>.Default.Equals(Sessoes, sala.Sessoes);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Capacidade, Sessoes);
        }
    }
}
