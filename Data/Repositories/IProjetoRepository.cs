using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public interface IProjetoRepository
    {
        List<Projeto> BuscarTodos();

        Projeto Adicionar(Projeto projeto);
    }
}
