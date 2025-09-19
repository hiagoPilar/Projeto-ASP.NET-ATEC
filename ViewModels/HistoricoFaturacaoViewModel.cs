using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_ASP.NET_Core_ATEC.ViewModels
{
    
    public class HistoricoFaturacaoViewModel
    {
        public string NomeCliente { get; set; }
        public string NumeroContrato { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal Valor { get; set; }
    }
}