namespace ApiBiblioteca.DTOs
{
    public class EmprestimoDTO
    {
        public Guid LivroId { get; set; }
        public Guid AlunoId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
