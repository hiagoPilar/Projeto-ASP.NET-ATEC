using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_ASP.NET_Core_ATEC.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número do contrato é obrigatório")]
        [StringLength(50)]
        public string NumeroContrato { get; set; }

        [Required(ErrorMessage = "A descrição do contrato é obrigatória.")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor {  get; set; }
        public string Condicoes { get; set; }


        [Required(ErrorMessage = "O cliente é obrigatório.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        
        public int? ProjetoId { get; set; }

        [ForeignKey("ProjetoId")]
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
