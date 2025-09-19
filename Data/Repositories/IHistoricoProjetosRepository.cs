using Projeto_ASP.NET_Core_ATEC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories.Interfaces
{
    public interface IHistoricoProjetosRepository
    {
        Task<IEnumerable<HistoricoProjetosViewModel>> GetHistoricoProjetosPorFuncionarioAsync(int funcionarioId);
    }
}