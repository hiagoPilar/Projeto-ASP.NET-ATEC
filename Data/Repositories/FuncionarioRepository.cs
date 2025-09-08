using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        
        private readonly BancoContext _bancoContext;

        public FuncionarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Funcionario> BuscarTodos()
        {
            return _bancoContext.Funcionarios.ToList();
        }

        public Funcionario ListarPorId(int id)
        {
            return _bancoContext.Funcionarios.FirstOrDefault(x => x.Id == id);
        }

        public Funcionario AdicionarFuncionario(Funcionario funcionario)
        {
            _bancoContext.Funcionarios.Add(funcionario);
            _bancoContext.SaveChanges();
            return funcionario;
        }

        public Funcionario Atualizar(Funcionario funcionario)
        {
            Funcionario funcionarioDB = ListarPorId(funcionario.Id);

            if (funcionarioDB == null) throw new System.Exception("Houve um erro!");

            funcionarioDB.Nome = funcionario.Nome;
            funcionarioDB.Email = funcionario.Email;
            funcionarioDB.Especializacao = funcionario.Especializacao;
            funcionarioDB.DataContratacao = funcionario.DataContratacao;

            _bancoContext.Funcionarios.Update(funcionarioDB);
            _bancoContext.SaveChanges();
            return funcionarioDB;

        }

        public bool Apagar(int id)
        {
            Funcionario funcionarioDB = ListarPorId(id);

            if(funcionarioDB == null) throw new System.Exception("Houve um erro!");

            _bancoContext.Funcionarios.Remove(funcionarioDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
