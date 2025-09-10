using Microsoft.AspNetCore.Mvc.ModelBinding;
using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Usuario> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public bool Apagar(int id)
        {
            Usuario usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new Exception("Houve um erro");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public Usuario Atualizar(Usuario usuario)
        {
            Usuario usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Login = usuario.Login;
            usuario.Email = usuario.Email;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();
            return usuarioDB;
        }

        public Usuario CriarNovoUsuario(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public Usuario ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        
    }
}
