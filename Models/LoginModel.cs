using System.ComponentModel.DataAnnotations;
 

namespace Projeto_ASP.NET_Core_ATEC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string Login {  get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}
