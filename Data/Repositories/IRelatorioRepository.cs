using Projeto_ASP.NET_Core_ATEC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<IEnumerable<RelatorioProjetosViewModel>> GetProjetosAtivosPorClienteAsync(int clienteId);
        Task<IEnumerable<HistoricoFaturacaoViewModel>> GetHistoricoFaturacaoAsync();
        // Adicione outros métodos de relatório aqui
    }
}