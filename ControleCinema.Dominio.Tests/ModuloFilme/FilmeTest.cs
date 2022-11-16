using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Teste_ControleDeCinema.Dominio.ModuloFilme;

namespace ControleCinema.Dominio.Tests.ModuloFilme
{
    [TestClass]
    public class FilmeTest
    {
        private readonly Filme filme;
        private readonly ValidadorFilme validador;

        public FilmeTest()
        {
            filme = new()
            {
                Titulo = "Rumo ao Hexa",
                Duracao = new TimeSpan(0, 01, 40, 00),
                Descricao = "Fala da busca do brasil para a conquista do tão sonhado hexa",
                Imagem = new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, },
            };
            validador = new ValidadorFilme();
        }

        [TestMethod]
        public void Titulo_Do_Filme_É_Obrigatório()
        {
            //arrenge
            filme.Titulo = null;

            //action
            var outroResultado = validador.TestValidate(filme);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(filme => filme.Titulo);
        }

        [TestMethod]
        public void Titulo_Do_Filme_Deve_Ser_Preenchido()
        {
            //arrenge
            filme.Titulo = "";

            //action
            var outroResultado = validador.TestValidate(filme);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(filme => filme.Titulo);
        }

        [TestMethod]
        public void A_Descricao_Do_Filme_É_Obrigatória()
        {
            //arrenge
            filme.Descricao = null;

            //action
            var outroResultado = validador.TestValidate(filme);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(filme => filme.Descricao);
        }

        [TestMethod]
        public void A_Descricao_Do_Filme_Deve_Ser_Preenchida()
        {
            //arrenge
            filme.Descricao = "";

            //action
            var outroResultado = validador.TestValidate(filme);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(filme => filme.Descricao);
        }

        [TestMethod]
        public void A_Duaracao_Do_Filme_Deve_Ser_Preenchida()
        {
            //arrenge
            filme.Duracao = new();

            //action
            var outroResultado = validador.TestValidate(filme);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(filme => filme.Duracao);
        }

        [TestMethod]
        public void A_Imagem_Do_Filme_Deve_Ser_Preenchida()
        {
            //arrenge
            filme.Imagem = default;

            //action
            var outroResultado = validador.TestValidate(filme);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(filme => filme.Imagem);
        }
    }
}
