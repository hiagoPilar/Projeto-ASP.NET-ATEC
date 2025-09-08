using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public interface IClienteRepository
    {

        Cliente ListarPorId(int id);
        
        List<Cliente> BuscarTodos();

        Cliente Atualizar(Cliente cliente);

        bool Apagar(int id);

        Cliente AdicionarNovoCliente(Cliente cliente);

        Cliente ContratosClienteAtivos(Cliente cliente);

        Cliente HistoricoFaturacao(Cliente cliente);
    }
}
