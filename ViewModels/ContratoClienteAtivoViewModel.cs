namespace Projeto_ASP.NET_Core_ATEC.ViewModels
{
    public class ContratoClienteAtivoViewModel
    {
        public int Id { get; set; }
        public string NumeroContrato { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; } // pode ser null
        public decimal Valor { get; set; }
    }
}
