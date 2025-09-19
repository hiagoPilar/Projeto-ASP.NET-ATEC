using Microsoft.AspNetCore.Mvc;
using Projeto_ASP.NET_Core_ATEC.Data;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories;
using Projeto_ASP.NET_Core_ATEC.Enums;
using Projeto_ASP.NET_Core_ATEC.Filters;
using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{
    [PaginaParaUsuarioLogado]
    [PaginaRestritaPorPerfil(PerfilEnum.Admin)]
    public class FuncionarioController : Controller
    {
        
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        
        public IActionResult Index()
        {
            List<Funcionario> funcionarios = _funcionarioRepository.BuscarTodos();
            return View(funcionarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Funcionario funcionario = _funcionarioRepository.ListarPorId(id);
            return View(funcionario);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            Funcionario funcionario = _funcionarioRepository.ListarPorId(id);
            return View(funcionario);
        }

        public IActionResult Delete(int id)
        {
            _funcionarioRepository.Apagar(id);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Create(Funcionario funcionario)
        {
            _funcionarioRepository.AdicionarFuncionario(funcionario);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Funcionario funcionario)
        {
            _funcionarioRepository.Atualizar(funcionario);
            return RedirectToAction("Index");
        }
    }
}
