namespace Projeto_ASP.NET_Core_ATEC.Models
{
    public class ProjetoFuncionario
    {
        public int Id { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int HorasTrabalhadas { get; set; }
        public string Funcao { get; set; }

    }
}
