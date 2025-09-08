namespace Projeto_ASP.NET_Core_ATEC.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
        public ICollection<Projeto> Projetos { get; set; }
    }
}
