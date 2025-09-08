using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BancoContext _bancoContext;

        public ClienteRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        
        public Cliente AdicionarNovoCliente(Cliente cliente)
        {
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();
            return cliente;
        }

        public Cliente ListarPorId(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }


        public Cliente Atualizar(Cliente cliente)
        {
            Cliente clienteDB = ListarPorId(cliente.Id);

            if (clienteDB == null) throw new System.Exception("Houve um erro!");

            clienteDB.Nome = cliente.Nome;
            clienteDB.Email = cliente.Email;

            _bancoContext.Clientes.Update(clienteDB);
            _bancoContext.SaveChanges();
            return clienteDB;
        }

        public List<Cliente> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }

        

        public bool Apagar(int id)
        {
            Cliente clienteDB = ListarPorId(id);

            if (clienteDB == null) throw new System.Exception("Houove um erro!");

            _bancoContext.Clientes.Remove(clienteDB);
            _bancoContext.SaveChanges();
            return true;

        }

        public Cliente ContratosClienteAtivos(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente HistoricoFaturacao(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
