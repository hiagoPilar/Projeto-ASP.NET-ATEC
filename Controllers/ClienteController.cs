using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories;
using Projeto_ASP.NET_Core_ATEC.Models;
using System.Threading.Tasks;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{
    
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public ClienteController(IClienteRepository clienteRepository, UserManager<IdentityUser> userManager)
        {
            _clienteRepository = clienteRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
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
            if (ModelState.IsValid)
            {
                _clienteRepository.AdicionarNovoCliente(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Atualizar(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        
    }
}
