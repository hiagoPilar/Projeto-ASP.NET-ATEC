using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario);
        void RemoverSessaoUsuario();
        Usuario BuscarSessaoDoUsuario();

    }
}
