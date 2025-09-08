using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly BancoContext _bancoContext;

        public ProjetoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        
        public Projeto Adicionar(Projeto projeto)
        {
            _bancoContext.Projetos.Add(projeto);
            _bancoContext.SaveChanges();
            return projeto;
        }

        public List<Projeto> BuscarTodos()
        {
            return _bancoContext.Projetos.ToList();
        }
    }
}
