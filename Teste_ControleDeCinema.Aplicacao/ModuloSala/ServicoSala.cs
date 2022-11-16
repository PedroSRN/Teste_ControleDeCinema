using FluentResults;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Aplicacao.Compartilhado;
using Teste_ControleDeCinema.Dominio.Compartilhado;
using Teste_ControleDeCinema.Dominio.ModuloSala;

namespace Teste_ControleDeCinema.Aplicacao.ModuloSala
{
    public class ServicoSala : ServicoBase<Sala, ValidadorSala>
    {
        private IRepositorioSala repositorioSala;
        private IContextoPersistencia contextoPersistencia;

        public ServicoSala(IRepositorioSala repositorioSala,
                             IContextoPersistencia contexto)
        {
            this.repositorioSala = repositorioSala;
            this.contextoPersistencia = contexto;
        }

        public Result<Sala> Inserir(Sala sala)
        {
            Log.Logger.Debug("Tentando inserir sala... {@s}", sala);

            Result resultado = Validar(sala);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                repositorioSala.Inserir(sala);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Sala {SalaId} inserida com sucesso", sala.Id);

                return Result.Ok(sala);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar inserir a Sala";

                Log.Logger.Error(ex, msgErro + " {SalaId} ", sala.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Sala> Editar(Sala sala)
        {
            Log.Logger.Debug("Tentando editar sala... {@s}", sala);

            var resultado = Validar(sala);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                repositorioSala.Editar(sala);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Sala {SalaId} editado com sucesso", sala.Id);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar editar a Sala";

                Log.Logger.Error(ex, msgErro + " {SalaId}", sala.Id);

                return Result.Fail(msgErro);
            }

            return Result.Ok(sala);
        }

        public Result Excluir(Guid id)
        {
            var salaResult = SelecionarPorId(id);

            if (salaResult.IsSuccess)
                return Excluir(salaResult.Value);

            return Result.Fail(salaResult.Errors);
        }

        public Result Excluir(Sala sala)
        {
            Log.Logger.Debug("Tentando excluir sala... {@s}", sala);

            try
            {
                repositorioSala.Excluir(sala);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Sala {SalaId} excluida com sucesso", sala.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir a Sala";

                Log.Logger.Error(ex, msgErro + " {SalaId}", sala.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Sala>> SelecionarTodos(Guid usuarioId = new Guid())
        {
            Log.Logger.Debug("Tentando selecionar salas...");

            try
            {
                var salas = repositorioSala.SelecionarTodos(usuarioId);

                Log.Logger.Information("Salas selecionados com sucesso");

                return Result.Ok(salas);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as Salas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Sala> SelecionarPorId(Guid id)
        {
            Log.Logger.Debug("Tentando selecionar sala {SalaId}...", id);

            try
            {
                var sala = repositorioSala.SelecionarPorId(id);

                if (sala == null)
                {
                    Log.Logger.Warning("Sala {SalaId} não encontrada", id);

                    return Result.Fail("Sala não encontrada");
                }

                Log.Logger.Information("Sala {SalaId} selecionada com sucesso", id);

                return Result.Ok(sala);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a Sala";

                Log.Logger.Error(ex, msgErro + " {SalaId}", id);

                return Result.Fail(msgErro);
            }
        }
    }
}
