using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Contracts
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> GetAlunos();

        Task<Aluno> GetAluno(int? id);
        Task<Aluno> AddAluno(Aluno aluno);
        Task<int> UpdateAluno(int id, Aluno alunoAlterado);

        Task DeleteAluno(int id);
    }
}
