using Microsoft.AspNetCore.Mvc;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories;
using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            List<Cliente> clientes = _clienteRepository.BuscarTodos(); 
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Cliente cliente = _clienteRepository.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            Cliente cliente = _clienteRepository.ListarPorId(id);
            
            return View(cliente);
        }

        public IActionResult Delete(int id)
        {
            _clienteRepository.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            _clienteRepository.AdicionarNovoCliente(cliente);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);
            return RedirectToAction("Index");
        }

        
    }
}
