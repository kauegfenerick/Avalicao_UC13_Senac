using CadastroAluno.Models;
using System;
using Xunit;

namespace CadastroAluno.Test
{
    public class AlunoTest
    {
        [Fact]
        public void AtualizarDadosTeste()
        {
            //arrange
            Aluno aluno = new Aluno();

            //act
            aluno.AtualizarDados("Kauê","t91");

            //assert
            //Assert.
        }
    }
}
