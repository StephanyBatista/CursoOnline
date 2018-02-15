using System;
using System.Collections.Generic;
using System.Text;
using CursoOnline.Dominio._base;
using CursoOnline.DominioTest._util;
using ExpectedObjects;
using Xunit;
using Xunit.Sdk;

namespace CursoOnline.DominioTest.Cursos
{
    //"Eu, enquanto administrador, quero criar e editar cursos para que sejam abertas matriculas para o mesmo."

    //Critério de aceite

    //- Criar um curso com nome, carga horária, publico alvo e valor do curso.
    //- As opções para publico alvo são: Estudante, Universitário, Empregado e Empreendedor.
    //- Todos os campos do curso são obrigatórios.

    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };

            Assert.Throws<ValidadorDeRegra<Curso>>(() => 
                new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .ComMensagem("Nome inválido 2");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };

            var message = Assert.Throws<ValidadorDeRegra<Curso>>(() =>
                new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;
            Assert.Equal("Carga horária inválida", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaUmValorMenorQue1(double valorInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };

            var message = Assert.Throws<ValidadorDeRegra<Curso>>(() =>
                new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido))
                .Message;
            Assert.Equal("Valor inválido", message);
        }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitário,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            ValidadorDeRegra<Curso>.Criar()
                .Validar(string.IsNullOrEmpty(nome), "Nome inválido")
                .Validar(cargaHoraria < 1, "Carga horária inválida")
                .Validar(valor < 1, "Valor inválido")
                .LancarExcecao();

            //if (string.IsNullOrEmpty(nome))
            //    throw new ArgumentException("Nome inválido");

            //if(cargaHoraria < 1)
            //    throw new ArgumentException("Carga horária inválida");

            //if(valor < 1)
            //    throw new ArgumentException("Valor inválido");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
    }
}
