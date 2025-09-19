namespace Projeto_ASP.NET_Core_ATEC.ViewModels
{
    public class RelatorioProjetosViewModel
    {
        public int ProjetoId { get; set; }
        public string NomeProjeto { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public decimal Orcamento { get; set; }
        
    }
}
