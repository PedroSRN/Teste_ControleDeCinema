using System;
using System.Collections.Generic;
using Teste_ControleDeCinema.Dominio.Compartilhado;
using Teste_ControleDeCinema.Dominio.ModuloAutenticacao;
using Teste_ControleDeCinema.Dominio.ModuloFilme;
using Teste_ControleDeCinema.Dominio.ModuloSala;

namespace Teste_ControleDeCinema.Dominio.ModuloSessao
{
    public class Sessao : EntidadeBase<Sessao>
    {
        private Filme _filme;
        private Sala _sala;

        public Sessao()
        {

        }

        public Sessao(DateTime data, TimeSpan horaInicio, TimeSpan horaTermino, TipoSessaoEnum tipoSessao, TipoAudioEnum tipoAudio, decimal valorIngresso, Filme filme, Sala sala)
        {
            Data = data;
            HoraInicio = horaInicio;
            TipoSessao = tipoSessao;
            TipoAudio = tipoAudio;
            ValorIngresso = valorIngresso;
            Filme = filme;
            Sala = sala;
            HoraTermino = horaTermino;
           // HoraTermino = horaInicio + filme.Duracao; //
        }


        public DateTime Data { get; set; }
        public TimeSpan HoraInicio  { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public TipoSessaoEnum TipoSessao { get; set; }
        public TipoAudioEnum TipoAudio { get; set; }
        public  decimal ValorIngresso { get; set; }
        public Filme Filme 
        {
            get { return _filme; }
            set 
            {
                _filme = value;

                if (_filme != null)
                    FilmeId = _filme.Id;
            }
        }
        public Guid? FilmeId { get; set; }

        public Sala Sala
        {
            get { return _sala; }
            set
            {
                _sala = value;

                if( _sala != null )
                    SalaId = _sala.Id;
            }
        }
        public Guid? SalaId { get; set; }

        public override void Atualizar(Sessao registro)
        {
            Id = registro.Id;
            Data = registro.Data;
            HoraInicio = registro.HoraInicio;
            HoraTermino = registro.HoraTermino;
            TipoSessao = registro.TipoSessao;
            TipoAudio = registro.TipoAudio;
            ValorIngresso = registro.ValorIngresso;
            Filme = registro.Filme;
            Sala = registro.Sala;
        }

        public override bool Equals(object obj)
        {
            return obj is Sessao sessao &&
                   Id.Equals(sessao.Id) &&
                   EqualityComparer<Filme>.Default.Equals(_filme, sessao._filme) &&
                   EqualityComparer<Sala>.Default.Equals(_sala, sessao._sala) &&
                   Data == sessao.Data &&
                   HoraInicio.Equals(sessao.HoraInicio) &&
                   HoraTermino.Equals(sessao.HoraTermino) &&
                   TipoSessao == sessao.TipoSessao &&
                   TipoAudio == sessao.TipoAudio &&
                   ValorIngresso == sessao.ValorIngresso &&
                   EqualityComparer<Filme>.Default.Equals(Filme, sessao.Filme) &&
                   EqualityComparer<Guid?>.Default.Equals(FilmeId, sessao.FilmeId) &&
                   EqualityComparer<Sala>.Default.Equals(Sala, sessao.Sala) &&
                   EqualityComparer<Guid?>.Default.Equals(SalaId, sessao.SalaId);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(_filme);
            hash.Add(_sala);
            hash.Add(Data);
            hash.Add(HoraInicio);
            hash.Add(HoraTermino);
            hash.Add(TipoSessao);
            hash.Add(TipoAudio);
            hash.Add(ValorIngresso);
            hash.Add(Filme);
            hash.Add(FilmeId);
            hash.Add(Sala);
            hash.Add(SalaId);
            return hash.ToHashCode();
        }

        public bool NaoPodeExcluir()
        {
            return (Data - DateTime.Now).TotalDays < 10;
        }
    }
}
