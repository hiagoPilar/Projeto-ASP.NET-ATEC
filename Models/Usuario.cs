using Projeto_ASP.NET_Core_ATEC.Enums;

namespace Projeto_ASP.NET_Core_ATEC.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public PerfilEnum Perfil { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

    }
}
