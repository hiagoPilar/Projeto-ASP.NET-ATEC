using System.ComponentModel.DataAnnotations;

namespace Projeto_ASP.NET_Core_ATEC.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        [Display(Name = "Nome do Cliente")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Formato de email inválido.")]
        public string Email { get; set; }


        public ICollection<Contrato> Contratos { get; set; }
        public ICollection<Projeto> Projetos { get; set; }
    }
}
