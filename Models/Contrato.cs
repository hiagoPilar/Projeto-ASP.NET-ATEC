namespace Projeto_ASP.NET_Core_ATEC.Models
{
    public class Contrato
    {
        public int Id { get; set; }

        public string NumeroContrato { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal Valor {  get; set; }
        public string Condicoes { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int? ProjetoId { get; set; }
        public Projeto Projeto { get; set; }

    }
}
