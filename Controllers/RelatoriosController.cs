using Microsoft.AspNetCore.Mvc;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories;
using System.Threading.Tasks;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public RelatoriosController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IActionResult> ProjetosAtivos()
        {
            var relatorio = await _clienteRepository.GetRelatorioProjetosAtivosAsync();
            return View(relatorio);
        }
    }
}