using System.Text.Json.Serialization;

namespace ApiBiblioteca.Models
{
    public class Aluno
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public ICollection<Emprestimo> Emprestimos { get; set; }

    }
}
