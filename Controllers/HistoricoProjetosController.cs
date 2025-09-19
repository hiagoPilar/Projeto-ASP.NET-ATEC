using Microsoft.AspNetCore.Mvc;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories.Interfaces; // Adicione este using
using System.Threading.Tasks;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{
    public class HistoricoProjetosController : Controller
    {
        private readonly IHistoricoProjetosRepository _historicoRepository;

        public HistoricoProjetosController(IHistoricoProjetosRepository historicoRepository)
        {
            _historicoRepository = historicoRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            var historico = await _historicoRepository.GetHistoricoProjetosPorFuncionarioAsync(id);
            return View("~/Views/Relatorios/HistoricoProjetos.cshtml", historico);
        }
    }
}