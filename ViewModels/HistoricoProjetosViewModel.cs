namespace Projeto_ASP.NET_Core_ATEC.ViewModels
{
    public class HistoricoProjetosViewModel
    {
        public int FuncionarioId { get; set; }
        public string NomeFuncionario { get; set; } = string.Empty;
        public int ProjetoId { get; set; }
        public string NomeProjeto { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
