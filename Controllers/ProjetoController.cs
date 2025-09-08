using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories;
using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IClienteRepository _clienteRepository;

        public ProjetoController(IProjetoRepository projetoRepository, IClienteRepository clienteRepository)
        {
            _projetoRepository = projetoRepository;
            _clienteRepository = clienteRepository;
        }

        
        public IActionResult Index()
        {
            List<Projeto> projetos = _projetoRepository.BuscarTodos();
            return View(projetos);
        }

        public IActionResult Create()
        {
            //carrega a lista de clientes para o dropdown
            var clientes = _clienteRepository.BuscarTodos();

            if (clientes == null || !clientes.Any())
            {
                // Redirecione ou mostre mensagem se não houver clientes
                ViewData["MensagemErro"] = "É necessário cadastrar clientes primeiro.";
                return View();
            }

            ViewData["ClienteId"] = new SelectList(clientes, "Id", "Nome");
            return View();
        }



        [HttpPost]
        public IActionResult Create(Projeto projeto)
        {
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
            ViewData["ClienteId"] = new SelectList(clientes, "Id", "Nome", projeto.ClienteId);

            return View(projeto);

        }
    }

}
