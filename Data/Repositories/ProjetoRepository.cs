using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Projeto_ASP.NET_Core_ATEC.Data;
using Projeto_ASP.NET_Core_ATEC.Models;
using Projeto_ASP.NET_Core_ATEC.ViewModels;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly BancoContext _bancoContext;

        public ProjetoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Projeto> BuscarTodos()
        {
           
            return _bancoContext?.Projetos?.ToList() ?? new List<Projeto>();
        }

        public Projeto Adicionar(Projeto projeto)
        {
            _bancoContext.Projetos.Add(projeto);
            _bancoContext.SaveChanges();
            return projeto;
        }

        public async Task<IEnumerable<RelatorioProjetosViewModel>> GetProjetosAtivosPorClienteAsync(int clienteId)
        {
            if (_bancoContext == null)
                return Enumerable.Empty<RelatorioProjetosViewModel>();

            var param = new SqlParameter("@ClienteId", clienteId);

            var projetos = await _bancoContext.RelatorioProjetosViewModel
                                .FromSqlRaw("EXEC dbo.GetProjetosAtivosPorCliente @ClienteId", param)
                                .ToListAsync();

            return projetos ?? Enumerable.Empty<RelatorioProjetosViewModel>();
        }
    }
}
