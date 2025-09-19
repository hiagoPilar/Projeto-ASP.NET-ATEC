using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories.Interfaces;
using Projeto_ASP.NET_Core_ATEC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly BancoContext _bancoContext;

        public RelatorioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<IEnumerable<RelatorioProjetosViewModel>> GetProjetosAtivosPorClienteAsync(int clienteId)
        {
            var pClienteId = new SqlParameter("@ClienteId", clienteId);

            var projetos = await _bancoContext.RelatorioProjetosViewModel
                               .FromSqlRaw("EXEC GetProjetosAtivosPorCliente @ClienteId", pClienteId)
                               .ToListAsync();

            return projetos;
        }

        public async Task<IEnumerable<HistoricoFaturacaoViewModel>> GetHistoricoFaturacaoAsync()
        {
            var historico = await _bancoContext.HistoricoFaturacaoViewModel
                                               .FromSqlRaw("EXEC GetHistoricoFaturacao")
                                               .ToListAsync();
            return historico;
        }
    }
}