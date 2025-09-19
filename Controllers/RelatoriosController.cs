using Microsoft.AspNetCore.Mvc;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories.Interfaces;
using Projeto_ASP.NET_Core_ATEC.ViewModels;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatoriosController(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public async Task<IActionResult> ProjetosAtivos(int clienteId)
        {
            // Aqui você pode passar um clienteId fixo para testar, ou vir de query string
            var projetosAtivos = await _relatorioRepository.GetProjetosAtivosPorClienteAsync(clienteId);
            return View(projetosAtivos);
        }
       
    }
}
