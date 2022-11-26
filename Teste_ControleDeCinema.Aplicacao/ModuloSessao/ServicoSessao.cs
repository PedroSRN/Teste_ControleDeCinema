using FluentResults;
using FluentValidation.Results;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Aplicacao.Compartilhado;
using Teste_ControleDeCinema.Dominio.Compartilhado;
using Teste_ControleDeCinema.Dominio.ModuloFilme;
using Teste_ControleDeCinema.Dominio.ModuloSala;
using Teste_ControleDeCinema.Dominio.ModuloSessao;

namespace Teste_ControleDeCinema.Aplicacao.ModuloSessao
{
    public class ServicoSessao : ServicoBase<Sessao, ValidadorSessao>
    {
        private IRepositorioSessao repositorioSessao;
        private IRepositorioSala repositorioSala;
        private IContextoPersistencia contextoPersistencia;
  


        public ServicoSessao(IRepositorioSessao repositorioSessao, IRepositorioSala repositorioSala,
                                IContextoPersistencia contexto)
        {
            this.repositorioSessao = repositorioSessao;
            this.repositorioSala = repositorioSala;
            this.contextoPersistencia = contexto;
        }

        public Result<Sessao> Inserir(Sessao sessao)
        {
            Log.Logger.Debug("Tentando inserir sessao... {@s}", sessao);

            Result resultado = Validar(sessao);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {

                repositorioSessao.Inserir(sessao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Sessao {SessaoId} inserida com sucesso", sessao.Id);

                return Result.Ok(sessao);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar inserir a Sessao";

                Log.Logger.Error(ex, msgErro + " {SessaoId} ", sessao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Sessao> Editar(Sessao sessao)
        {
            Log.Logger.Debug("Tentando editar sessao... {@s}", sessao);

            var resultado = Validar(sessao);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                repositorioSessao.Editar(sessao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Sessao {SessaoId} editado com sucesso", sessao.Id);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar editar a Sessao";

                Log.Logger.Error(ex, msgErro + " {SessaoId}", sessao.Id);

                return Result.Fail(msgErro);
            }

            return Result.Ok(sessao);
        }

        public Result Excluir(Guid id)
        {
            var sessaoResult = SelecionarPorId(id);

            if (sessaoResult.IsSuccess)
                return Excluir(sessaoResult.Value);

            return Result.Fail(sessaoResult.Errors);
        }

        public Result Excluir(Sessao sessao)
        {
            Log.Logger.Debug("Tentando excluir sessao... {@s}", sessao);


            if (sessao.NaoPodeExcluir())
            {
                return Result.Fail("Uma sessão só pode ser removida se faltar 10 dias ou mais para que ela ocorra.");
            }

            try
            {
                repositorioSessao.Excluir(sessao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Sessao {SessaoId} excluida com sucesso", sessao.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir a Sessao";

                Log.Logger.Error(ex, msgErro + " {SalaId}", sessao.Id);

                return Result.Fail(msgErro);
            }
        }

       

        public Result<List<Sessao>> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando selecionar sessoes...");

            try
            {
                var sessoes = repositorioSessao.SelecionarTodos();

                Log.Logger.Information("Sessoes selecionados com sucesso");

                return Result.Ok(sessoes);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as Sessoes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Sessao> SelecionarPorId(Guid id)
        {
            Log.Logger.Debug("Tentando selecionar sessao {SessaoId}...", id);

            try
            {
                var sala = repositorioSessao.SelecionarPorId(id);

                if (sala == null)
                {
                    Log.Logger.Warning("Sessao {SessaoId} não encontrada", id);

                    return Result.Fail("Sessao não encontrada");
                }

                Log.Logger.Information("Sessao {SessaoId} selecionada com sucesso", id);

                return Result.Ok(sala);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a Sessao";

                Log.Logger.Error(ex, msgErro + " {SessaoId}", id);

                return Result.Fail(msgErro);
            }
        }

       
    }
}
