using System;
using System.Text.RegularExpressions;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.PublicosAlvo;
using CursoOnline.Dominio._Base;

namespace CursoOnline.Dominio.Alunos
{
    public class Aluno : Entidade
    {
        private readonly Regex _emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        private readonly Regex _cpfRegex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }

        private Aluno() { }

        public Aluno(string nome, string email, string cpf, PublicoAlvo publicoAlvo)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), Resource.NomeInvalido)
                .Quando(string.IsNullOrEmpty(email) || !_emailRegex.Match(email).Success, Resource.EmailInvalido)
                .Quando(string.IsNullOrEmpty(cpf) || !_cpfRegex.Match(cpf).Success, Resource.CpfInvalido)
                .DispararExcecaoSeExistir();

            Nome = nome;
            Cpf = cpf;
            Email = email;
            PublicoAlvo = publicoAlvo;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
    }
}