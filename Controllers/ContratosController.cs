using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_ASP.NET_Core_ATEC.Data;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories.Interfaces;
using Projeto_ASP.NET_Core_ATEC.Enums;
using Projeto_ASP.NET_Core_ATEC.Filters;
using Projeto_ASP.NET_Core_ATEC.Models;
using Projeto_ASP.NET_Core_ATEC.ViewModels;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{
    [PaginaParaUsuarioLogado]
    [PaginaRestritaPorPerfil(PerfilEnum.Admin, PerfilEnum.Gestor)]
    public class ContratosController : Controller
    {
        private readonly IContratoRepository _contratoRepository;
        private readonly BancoContext _context;

        public ContratosController(IContratoRepository contratoRepository, BancoContext context)
        {
            _contratoRepository = contratoRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var contratos = await _contratoRepository.GetAllAsync();
            return View(contratos);
        }

        public async Task<IActionResult> HistoricoFaturacao()
        {
            var historico = await _contratoRepository.GetHistoricoFaturacaoAsync();
            return View("~/Views/Relatorios/HistoricoFaturacao.cshtml", historico);
        }

        public async Task<IActionResult> ContratosClienteAtivos(int clienteId)
        {
            var contratosAtivos = await _contratoRepository.GetContratosClienteAtivosAsync(clienteId);
            return View("~/Views/Relatorios/ContratosClienteAtivos.cshtml", contratosAtivos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var contrato = await _contratoRepository.GetByIdAsync(id.Value);
            if (contrato == null) return NotFound();
            return View(contrato);
        }

        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroContrato,Descricao,DataInicio,DataFim,Valor,Condicoes,ClienteId,ProjetoId")] Contrato contrato)
        {
            await _context.Contratos.AddAsync(contrato);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var contrato = await _contratoRepository.GetByIdAsync(id.Value);
            if (contrato == null) return NotFound();

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", contrato.ClienteId);
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "Id", "Id", contrato.ProjetoId);
            return View(contrato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroContrato,Descricao,DataInicio,DataFim,Valor,Condicoes,ClienteId,ProjetoId")] Contrato contrato)
        {
            if (id != contrato.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _contratoRepository.UpdateAsync(contrato);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", contrato.ClienteId);
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "Id", "Id", contrato.ProjetoId);
            return View(contrato);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var contrato = await _contratoRepository.GetByIdAsync(id.Value);
            if (contrato == null) return NotFound();
            return View(contrato);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _contratoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}