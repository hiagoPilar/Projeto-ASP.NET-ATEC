namespace Projeto_ASP.NET_Core_ATEC.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Especializacao { get; set; }
        public DateTime DataContratacao { get; set; }
        public ICollection<ProjetoFuncionario> Projetos { get; set; }

    }
}
