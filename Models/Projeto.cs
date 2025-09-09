using System.ComponentModel.DataAnnotations;

namespace Projeto_ASP.NET_Core_ATEC.Models
{
    public class Projeto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataFim { get; set; }

        [Required(ErrorMessage = "O orçamento é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O orçamento deve ser maior ou igual a zero.")]
        public decimal Orcamento { get; set; }

        [Required(ErrorMessage = "Selecione um cliente.")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<ProjetoFuncionario> Funcionarios { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
    }
}
