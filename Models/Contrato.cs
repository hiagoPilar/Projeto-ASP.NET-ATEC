using System.ComponentModel.DataAnnotations;

namespace Projeto_ASP.NET_Core_ATEC.Models
{
    public class Contrato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O número do contrato é obrigatório.")]
        [StringLength(50, ErrorMessage = "O número do contrato deve ter no máximo 50 caracteres.")]
        [Display(Name = "Número do Contrato")]
        public string NumeroContrato { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de fim é obrigatória.")]
        [Display(Name = "Data de Fim")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [CustomValidation(typeof(Contrato), "ValidarDataFim")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Valor { get; set; }

        [StringLength(1000, ErrorMessage = "As condições devem ter no máximo 1000 caracteres.")]
        [Display(Name = "Condições")]
        [DataType(DataType.MultilineText)]
        public string Condicoes { get; set; }


        [Required(ErrorMessage = "O cliente é obrigatório.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
        public int? ProjetoId { get; set; }
        public Projeto Projeto { get; set; }


        public static ValidationResult ValidarDataFim(DateTime dataFim, ValidationContext context)
        {
            var contrato = (Contrato)context.ObjectInstance;

            if(dataFim < contrato.DataInicio)
            {
                return new ValidationResult("A data de fim deve ser posterior a data de início.");
            }

            return ValidationResult.Success;
        }

    }
}
