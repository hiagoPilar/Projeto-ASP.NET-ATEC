using Projeto_ASP.NET_Core_ATEC.Models;
using Projeto_ASP.NET_Core_ATEC.ViewModels;
using System.Threading.Tasks;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories.Interfaces
{
    public interface IContratoRepository 
    {
        Task<IEnumerable<HistoricoFaturacaoViewModel>> GetHistoricoFaturacaoAsync();

        Task<IEnumerable<ContratoClienteAtivoViewModel>> GetContratosClienteAtivosAsync(int clienteId);
        Task<IEnumerable<Contrato>> GetAllAsync();
        Task<Contrato?> GetByIdAsync(int id);
        Task AddAsync(Contrato contrato);
        Task UpdateAsync(Contrato contrato);
        Task DeleteAsync(int id);

        // Método para a stored procedure de registro
        Task<bool> AdicionarNovoContratoValidadoAsync(Contrato contrato);
    }
}