namespace ApiBiblioteca.Models
{
    public class Emprestimo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid LivroId { get; set; }
        public Livro Livro { get; set; }
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
