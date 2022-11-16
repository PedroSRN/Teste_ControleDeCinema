using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Teste_ControleDeCinema.Aplicacao.ModuloFilme;
using Teste_ControleDeCinema.Dominio.ModuloFilme;
using Teste_ControleDeCinema.Webapi.Controllers.Compartilhado;
using Teste_ControleDeCinema.Webapi.ViewModels.ModuloFilme;

namespace Teste_ControleDeCinema.Webapi.Controllers
{
    [Route("api/filmes")]
    [ApiController]
    [Authorize]
    public class FilmeController : ControleCinemaControllerBase
    {
        private readonly ServicoFilme servicoFilme;
        private readonly IMapper mapeadorFilmes;

        public FilmeController(ServicoFilme servicoFilme, IMapper mapeadorFilmes)
        {
            this.servicoFilme = servicoFilme;
            this.mapeadorFilmes = mapeadorFilmes;
        }

        [HttpGet]
        public ActionResult<List<ListarFilmeViewModel>> SelecionarTodos()
        {
            var filmeResult = servicoFilme.SelecionarTodos(UsuarioLogado.Id);

            if (filmeResult.IsFailed)
                return InternalError(filmeResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorFilmes.Map<List<ListarFilmeViewModel>>(filmeResult.Value)
            });
        }

        [HttpGet("visualizacao-completa/{id:guid}")]
        public ActionResult<VisualizarFilmeViewModel> SelecionarFilmeCompletoPorId(Guid id)
        {
            var filmeResult = servicoFilme.SelecionarPorId(id);

            if (filmeResult.IsFailed && RegistroNaoEncontrado(filmeResult))
                return NotFound(filmeResult);

            if (filmeResult.IsFailed)
                return InternalError(filmeResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorFilmes.Map<VisualizarFilmeViewModel>(filmeResult.Value)
            });
        }

        [HttpGet("{id:guid}")]
        public ActionResult<FormsFilmeViewModel> SelecionarFilmePorId(Guid id)
        {
            var filmeResult = servicoFilme.SelecionarPorId(id);

            if (filmeResult.IsFailed && RegistroNaoEncontrado(filmeResult))
                return NotFound(filmeResult);

            if (filmeResult.IsFailed)
                return InternalError(filmeResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorFilmes.Map<FormsFilmeViewModel>(filmeResult.Value)
            });
        }

        [HttpPost]
        public ActionResult<FormsFilmeViewModel> Inserir(FormsFilmeViewModel filmeVM)
        {
            var filme = mapeadorFilmes.Map<Filme>(filmeVM);

            var filmeResult = servicoFilme.Inserir(filme);

            if (filmeResult.IsFailed)
                return InternalError(filmeResult);

            return Ok(new
            {
                sucesso = true,
                dados = filmeVM
            });
        }

        [HttpPut("{id:guid}")]
        public ActionResult<FormsFilmeViewModel> Editar(Guid id, FormsFilmeViewModel filmeVM)
        {
            var filmeResult = servicoFilme.SelecionarPorId(id);

            if (filmeResult.IsFailed && RegistroNaoEncontrado(filmeResult))
                return NotFound(filmeResult);

            var filme = mapeadorFilmes.Map(filmeVM, filmeResult.Value);

            filmeResult = servicoFilme.Editar(filme);

            if (filmeResult.IsFailed)
                return InternalError(filmeResult);

            return Ok(new
            {
                sucesso = true,
                dados = filmeVM
            });
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var filmeResult = servicoFilme.Excluir(id);

            if (filmeResult.IsFailed && RegistroNaoEncontrado<Filme>(filmeResult))
                return NotFound<Filme>(filmeResult);

            if (filmeResult.IsFailed)
                return InternalError<Filme>(filmeResult);

            return NoContent();
        }
    }
}
