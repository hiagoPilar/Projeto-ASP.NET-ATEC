using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_ASP.NET_Core_ATEC.Data;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories;
using Projeto_ASP.NET_Core_ATEC.Filters;
using Projeto_ASP.NET_Core_ATEC.Models;
using Projeto_ASP.NET_Core_ATEC.ViewModels;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{
    [PaginaParaUsuarioLogado]
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
        public async Task<IActionResult> ProjetosAtivos(int clienteId)
        {
            if (clienteId == 0)
                return BadRequest("ID do cliente não fornecido.");

            var projetos = await _projetoRepository.GetProjetosAtivosPorClienteAsync(clienteId)
                           ?? Enumerable.Empty<RelatorioProjetosViewModel>();

            return View("~/Views/Relatorios/ProjetosAtivos.cshtml", projetos);
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
