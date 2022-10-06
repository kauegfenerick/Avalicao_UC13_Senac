using CadastroAluno.Models;
using CadastroAluno.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace CadastroAluno.Test
{
    public class AlunoTest
    {
        [Theory]
        [InlineData("Kaue", "T92")]
        [InlineData("", "T94")]
        [InlineData("Pedro", "")]
        [InlineData("", "")]
        public void AtualizarDadosTesteRetornaTrueEmQualquerCircunstancia(string nome, string turma)
        {
            //arrange
            Aluno aluno = new Aluno();
            aluno.Nome = "Mael";
            aluno.Turma = "T91";

            //act
            aluno.AtualizarDados(nome, turma);

            //assert
            Assert.Equal(aluno.Nome, nome);
            Assert.Equal(aluno.Turma, turma);
        }
        [Theory]
        [InlineData(9)]
        public void MediaRetornaTrueCasoNotaMaiorQueOuIgualA5(double nota)
        {
            //arrange
            Aluno aluno = new Aluno();
            aluno.Media = nota;

            //act
            var result = aluno.VerificaAprovacao();

            //assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(5)]
        public void MediaRetornaFalseCasoNotaMaiorQueOuIgualA5(double nota)
        {
            //arrange
            Aluno aluno = new Aluno();
            aluno.Media = nota;

            //act
            var result = aluno.VerificaAprovacao();

            //assert
            Assert.False(result);
        }
        [Fact]
        public void AtualizaMediaAlteraMedia()
        {
            //arrange
            Aluno aluno = new Aluno();
            aluno.Media = 10;

            //act
            double result = 6;
            aluno.AtualizaMedia(result);

            //assert
            Assert.Equal(aluno.Media, result);
        }
    }
}
