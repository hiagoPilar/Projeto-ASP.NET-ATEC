using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Projeto_ASP.NET_Core_ATEC.ViewModels;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories.Interfaces; // Adicione este using
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    // Adicione a interface aqui
    public class HistoricoProjetosRepository : IHistoricoProjetosRepository
    {
        private readonly BancoContext _bancoContext;

        public HistoricoProjetosRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<IEnumerable<HistoricoProjetosViewModel>> GetHistoricoProjetosPorFuncionarioAsync(int funcionarioId)
        {
            try
            {
                var pFuncionarioId = new SqlParameter("@FuncionarioId", funcionarioId);

                var historico = await _bancoContext.HistoricoProjetosViewModel
                    .FromSqlRaw("EXEC GetHistoricoProjetosPorFuncionario @FuncionarioId", pFuncionarioId)
                    .AsNoTracking()
                    .ToListAsync();

                return historico;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Ocorreu um erro ao executar o stored procedure: {ex.Message}");
                return new List<HistoricoProjetosViewModel>();
            }
        }
    }
}