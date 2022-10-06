using Bogus;
using CadastroAluno.Contracts;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAluno.Test
{
    public class AlunosControllerTest
    {
        Mock<IAlunoRepository> _repository;
        Aluno aluno;

        public AlunosControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();
        }

        [Fact]
        public void IndexRetornaOkResultIndependente()
        {
            //arrange
            AlunosController controller = new AlunosController(_repository.Object);

            //act
            var alunos = controller.Index();

            //assert
            Assert.IsType<ViewResult>(alunos.Result);

        }

        [Fact]
        public void IndexChamaRepositoryApenasUmaVez()
        {
            //arrange
            AlunosController controller = new AlunosController(_repository.Object);

            //act
            _repository.Setup(r => r.GetAlunos()).Returns(Task.FromResult(new List<Aluno>()
                {}));

            //assert
        }
        [Fact]
        public void DetailsRetornaBadRequestParaIdNulo()
        {

        }
        [Fact]
        public void DetailsRetornaNotFoundParaIdInexistente()
        {

        }
        [Fact]
        public void DetailsRetornaViewParaIdExistente()
        {

        }
        [Fact]
        public void DetailsChamaRepositoryUmaVez()
        {

        }
        [Fact]
        public void CreateSempreRetornaView()
        {

        }
        [Fact]
        public void PostDeveValidaPropriedades()
        {

        }
    }
}
