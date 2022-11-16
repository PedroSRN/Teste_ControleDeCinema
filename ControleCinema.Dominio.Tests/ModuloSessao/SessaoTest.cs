using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Dominio.ModuloSessao;

namespace ControleCinema.Dominio.Tests.ModuloSessao
{
    [TestClass]
    public class SessaoTest
    {
        private readonly Sessao sessao;
        private readonly ValidadorSessao validador;

        public SessaoTest()
        {
            sessao = new()
            {
                Data = new(2022 / 12 / 12),
                HoraInicio = new TimeSpan(0, 18, 00, 00),
                HoraTermino = new TimeSpan(0, 19, 40, 00),
                TipoSessao = TipoSessaoEnum.tresD,
                TipoAudio = TipoAudioEnum.Legendado,
                ValorIngresso =  20,
                Filme = new(),
                Sala = new(),
            };
            validador = new ValidadorSessao();
        }

        [TestMethod]
        public void A_Data_Da_Sessao_Deve_Ser_Preenchida()
        {
            //arrenge
            sessao.Data = new();

            //action
            var outroResultado = validador.TestValidate(sessao);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(sessao => sessao.Data);
        }

        [TestMethod]
        public void A_Hora_De_Inicio_Da_Sessao_Deve_Ser_Preenchida()
        {
            //arrenge
            sessao.HoraInicio = new();

            //action
            var outroResultado = validador.TestValidate(sessao);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(sessao => sessao.HoraInicio);
        }

        [TestMethod]
        public void O_Tipo_De_Sessao_Deve_Ser_Preenchida()
        {
            //arrenge
            sessao.TipoSessao = default;

            //action
            var outroResultado = validador.TestValidate(sessao);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(sessao => sessao.TipoSessao);
        }

        [TestMethod]
        public void O_Tipo_De_Audio_Da_Sessao_Deve_Ser_Preenchido()
        {
            //arrenge
            sessao.TipoAudio = default;

            //action
            var outroResultado = validador.TestValidate(sessao);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(sessao => sessao.TipoAudio);
        }

        [TestMethod]
        public void O_Valor_Do_Ingresso_Da_Sessao_Deve_Ser_Preenchido()
        {
            //arrenge
            sessao.ValorIngresso = new();

            //action
            var outroResultado = validador.TestValidate(sessao);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(sessao => sessao.ValorIngresso);
        }

        [TestMethod]
        public void O_Valor_Do_Ingresso_Da_Sessao_Deve_Ser_Maior_Que_Zero()
        {
            //arrenge
            sessao.ValorIngresso = -1;

            //action
            var outroResultado = validador.TestValidate(sessao);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(sessao => sessao.ValorIngresso);
        }
    }
}
