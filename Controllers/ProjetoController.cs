using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_ASP.NET_Core_ATEC.Data;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories;
using Projeto_ASP.NET_Core_ATEC.Enums;
using Projeto_ASP.NET_Core_ATEC.Filters;
using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{
    [PaginaParaUsuarioLogado]
    [PaginaRestritaPorPerfil(PerfilEnum.Admin, PerfilEnum.Gestor, PerfilEnum.Funcionario)]
    
    public class ProjetoController : Controller
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly BancoContext _bancoContext;

        public ProjetoController(IProjetoRepository projetoRepository, IClienteRepository clienteRepository, BancoContext bancoContext)
        {
            _projetoRepository = projetoRepository;
            _clienteRepository = clienteRepository;
            _bancoContext = bancoContext;
        }

        
        public IActionResult Index()
        {
            List<Projeto> projetos = _projetoRepository.BuscarTodos();
            return View(projetos);
        }

        public IActionResult Create()
        {


            ViewBag.ClienteId = new SelectList(_bancoContext.Clientes, "Id", "Nome");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Projeto projeto)
        {

            _projetoRepository.Adicionar(projeto);
            return RedirectToAction("Index");

            /*
            if (ModelState.IsValid)
            {
                try
                {
                    _projetoRepository.Adicionar(projeto);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erro ao criar projeto: " + ex.Message);
                }
            }

            // Se chegou aqui, significa que houve erro
            // Recarrega os dados necessários para o dropdown
            var clientes = _clienteRepository.BuscarTodos() ?? new List<Cliente>();
            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nome", projeto.ClienteId);
            return View(projeto);
            */

        }
    }

}
