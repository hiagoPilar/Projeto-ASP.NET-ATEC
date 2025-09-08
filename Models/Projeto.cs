namespace Projeto_ASP.NET_Core_ATEC.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public decimal Orcamento { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<ProjetoFuncionario> Funcionarios { get; set; }
        public ICollection<Contrato> Contratos { get; set; }

    }
}
