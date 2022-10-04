using CadastroAluno.Contracts;
using CadastroAluno.Data;
using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroAluno.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
      private readonly CadastroAlunoContext _context;

        public AlunoRepository(CadastroAlunoContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> GetAlunos()
        {
            return await _context.Aluno.ToListAsync();
        }
        
        public async Task<Aluno> GetAluno(int id)
        {
            return await _context.Aluno.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
