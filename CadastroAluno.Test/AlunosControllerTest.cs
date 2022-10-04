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

        public AlunosControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();
        }
    }
}
