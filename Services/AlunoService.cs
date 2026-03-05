using ApiBiblioteca.Context;
using ApiBiblioteca.DTOs;
using ApiBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Services
{
    public class AlunoService
    {
        private readonly Db _context;
        public AlunoService(Db context) 
        {
            _context = context;
        }

        public async Task<List<Aluno>> GetAllAlunos() 
        {
            return await _context.Alunos
                .Include(c => c.Emprestimos)
                .ThenInclude(ac => ac.Livro)
                .ToListAsync();
        }
        public async Task<Aluno> GetAlunoById(Guid id) 
        {
            var aluno = await _context.Alunos
                    .Include(c => c.Emprestimos)
                    .ThenInclude(ac => ac.Livro)
                    .FirstOrDefaultAsync(a => a.Id == id);
            if (aluno == null) 
            {
                throw new KeyNotFoundException("Aluno não encontrado");
            }
            return aluno;
        }
        public async Task AddAluno(AlunoDTO dto) 
        {
            if (string.IsNullOrEmpty(dto.Nome) && (string.IsNullOrEmpty(dto.Email))) 
            {
                throw new ArgumentException("O nome e email do aluno é obrigatório");
            }
            var aluno = new Aluno
            {
                Nome = dto.Nome,
                Email = dto.Email
            };
            try
            {
                await _context.Alunos.AddAsync(aluno);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) 
            {
                throw new DbUpdateException("Erro ao inserir o aluno no banco de dados");
            }
        }

        public async Task UpdateAluno(Guid id, AlunoDTO dto) 
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);
            if (aluno == null)
                throw new KeyNotFoundException("Aluno não encontrado");
            
            if(string.IsNullOrWhiteSpace(dto.Nome) && string.IsNullOrWhiteSpace(dto.Email))
                throw new ArgumentException("O nome e email do aluno é obrigatório");

            aluno.Nome = dto.Nome;
            aluno.Email = dto.Email;

            try
            {
                _context.Alunos.Update(aluno);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) 
            {
                throw new DbUpdateException("Erro ao atualizar aluno no banco de dados");
            }
        }

        public async Task DeleteAluno(Guid id) 
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
                throw new KeyNotFoundException("Aluno não encontrado");

            try
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) 
            {
                throw new InvalidOperationException("Erro de integridade ao tentar deletar o aluno");
            }
        }
    }
}
