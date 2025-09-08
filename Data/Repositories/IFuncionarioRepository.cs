using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public interface IFuncionarioRepository
    {
        Funcionario ListarPorId(int id);
        
        List<Funcionario> BuscarTodos();

        Funcionario AdicionarFuncionario(Funcionario funcionario);

        Funcionario Atualizar(Funcionario funcionario);

        bool Apagar(int id);
    }
}
