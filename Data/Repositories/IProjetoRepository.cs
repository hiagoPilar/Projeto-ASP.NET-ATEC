using Projeto_ASP.NET_Core_ATEC.Models;
using Projeto_ASP.NET_Core_ATEC.ViewModels;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public interface IProjetoRepository
    {
        List<Projeto> BuscarTodos();
        Projeto Adicionar(Projeto projeto);
        Task<IEnumerable<RelatorioProjetosViewModel>> GetProjetosAtivosPorClienteAsync(int clienteId);
    }
}
