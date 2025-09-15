using Microsoft.AspNetCore.Mvc;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories;
using Projeto_ASP.NET_Core_ATEC.Filters;
using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        
        public IActionResult Index()
        {
            List<Usuario> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Usuario usuarioDB = _usuarioRepositorio.ListarPorId(id);
            return View(usuarioDB);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            Usuario usuarioDB = _usuarioRepositorio.ListarPorId(id);
            
            return View(usuarioDB);
        }

        public IActionResult Delete(int id)
        {
            _usuarioRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            usuario = _usuarioRepositorio.CriarNovoUsuario(usuario);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            _usuarioRepositorio.Atualizar(usuario);
            return RedirectToAction("Index");
        }

    }
}
