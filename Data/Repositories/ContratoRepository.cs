using Microsoft.EntityFrameworkCore;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories.Interfaces;
using Projeto_ASP.NET_Core_ATEC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly BancoContext _bancoContext;

        public ContratoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<IEnumerable<Contrato>> GetAllAsync()
        {
            return await _bancoContext.Contratos
                                    .Include(c => c.Cliente)
                                    .Include(c => c.Projeto)
                                    .ToListAsync();
        }

        public async Task<Contrato?> GetByIdAsync(int id)
        {
            return await _bancoContext.Contratos
                                    .Include(c => c.Cliente)
                                    .Include(c => c.Projeto)
                                    .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Contrato contrato)
        {
            await _bancoContext.Contratos.AddAsync(contrato);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contrato contrato)
        {
            _bancoContext.Contratos.Update(contrato);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contrato = await _bancoContext.Contratos.FindAsync(id);
            if (contrato != null)
            {
                _bancoContext.Contratos.Remove(contrato);
                await _bancoContext.SaveChangesAsync();
            }
        }

        public async Task<bool> AdicionarNovoContratoValidadoAsync(Contrato contrato)
        {
            var pNumeroContrato = new SqlParameter("@NumeroContrato", contrato.NumeroContrato);
            var pDescricao = new SqlParameter("@Descricao", contrato.Descricao);
            var pDataInicio = new SqlParameter("@DataInicio", contrato.DataInicio);
            var pDataFim = new SqlParameter("@DataFim", contrato.DataFim);
            var pValor = new SqlParameter("@Valor", contrato.Valor);
            var pCondicoes = new SqlParameter("@Condicoes", contrato.Condicoes ?? (object)DBNull.Value); // Nullable
            var pClienteId = new SqlParameter("@ClienteId", contrato.ClienteId);
            var pProjetoId = new SqlParameter("@ProjetoId", contrato.ProjetoId ?? (object)DBNull.Value); // Nullable

            var resultado = await _bancoContext.Database.ExecuteSqlRawAsync(
                "EXEC sp_AdicionarNovoContratoValidado @NumeroContrato, @Descricao, @DataInicio, @DataFim, @Valor, @Condicoes, @ClienteId, @ProjetoId",
                pNumeroContrato, pDescricao, pDataInicio, pDataFim, pValor, pCondicoes, pClienteId, pProjetoId);

            return resultado > 0;
        }

        public async Task<bool> ContratoExistsAsync(int id)
        {
            return await _bancoContext.Contratos.AnyAsync(e => e.Id == id);
        }
    }
}