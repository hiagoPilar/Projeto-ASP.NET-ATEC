using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin(string login);
        
        Usuario ListarPorId(int id);

        List<Usuario> BuscarTodos();

        Usuario CriarNovoUsuario(Usuario usuario);

        Usuario Atualizar(Usuario usuario);

        bool Apagar(int id);
    }
}
