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
        Aluno alunoValido;

        public AlunosControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();
        }

        [Fact]
        public async void IndexRetornaOkResultIndependente()
        {
            //arrange
            AlunosController controller = new AlunosController(_repository.Object);

            //act
            var alunos = await controller.Index();

            //assert
            Assert.IsType<ViewResult>(alunos);

        }

        [Fact]
        public async void IndexChamaRepositoryApenasUmaVez()
        {
            //Arrange
            var controller = new AlunosController(_repository.Object);

            _repository.Setup(r => r.AddAluno(alunoValido))
                .ReturnsAsync(alunoValido);

            //Act
            await controller.Create(alunoValido);

            //Assert 
            _repository.Verify(repo => repo.AddAluno(alunoValido), Times.Once);

        }
        [Fact]
        public async void DetailsRetornaBadRequestParaIdNulo()
        {
            //Arrange
            AlunosController controller = new AlunosController(_repository.Object);

            //Act
            var consulta = await controller.Details(-12);

            //Assert 
            Assert.IsType<BadRequestResult>(consulta);
        }
        [Fact]
        public async void DetailsRetornaNotFoundParaIdInexistente()
        {
            //Arrange
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.GetAluno(1))
               .Returns(Task.FromResult(alunoValido));
            //Act
            var consulta = await controller.Details(1);

            //Assert 
            Assert.IsType<NotFoundResult>(consulta);
        }
        [Fact]
        public async void DetailsRetornaViewParaIdExistente()
        {
            //arrange
            AlunosController controller = new AlunosController(_repository.Object);

            Aluno aluno = new Aluno();
            aluno.Id = 1;

            _repository.Setup(a => a.GetAluno(1))
               .ReturnsAsync(aluno);

            //act
            var result = await controller.Details(1);

            //assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async void DetailsChamaRepositoryUmaVez()
        {
            //arrange
            AlunosController controller = new AlunosController(_repository.Object);

            Aluno aluno = new Aluno();
            aluno.Id = 2;

            _repository.Setup(a => a.GetAluno(2))
                .ReturnsAsync(aluno);
        }
        [Fact]
        public async void CreateSempreRetornaView()
        {
            //Arrange
            AlunosController controller = new AlunosController(_repository.Object);

            //Act
            var result = controller.Create();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async void PostDeveValidaPropriedades()
        {
            //arrange
            AlunosController controller = new AlunosController(_repository.Object);

            Aluno aluno = new Aluno();

            aluno.Id = 1;
            aluno.Nome = null;
            aluno.Turma = null;
            aluno.Media = 10;

            //act
            var total = await controller.Create(aluno);

            //assert
            _repository.Verify(ar => ar.AddAluno(aluno), Times.Once);

            Assert.IsType<RedirectToActionResult>(total);
        }
    }
}
