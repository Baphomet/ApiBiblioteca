namespace ApiBiblioteca.Models
{
    public class Livro
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public bool IsDisponivel { get; set; }
        public ICollection<Emprestimo> Emprestimos { get; set; }

    }
}
