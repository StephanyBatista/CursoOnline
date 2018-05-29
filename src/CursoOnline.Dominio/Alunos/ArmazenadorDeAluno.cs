using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio._Base;

namespace CursoOnline.Dominio.Alunos
{
    public class ArmazenadorDeAluno
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public ArmazenadorDeAluno(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public void Armazenar(AlunoDto alunoDto)
        {
            var alunoComMesmoCpf = _alunoRepositorio.ObterPeloCpf(alunoDto.Cpf);

            ValidadorDeRegra.Novo()
                .Quando(alunoComMesmoCpf != null && alunoComMesmoCpf.Id != alunoDto.Id, Resource.CpfJaCadastrado)
                .DispararExcecaoSeExistir();

            if (alunoDto.Id == 0)
            {
                var aluno = new Aluno(alunoDto.Nome, alunoDto.Email, alunoDto.Cpf, PublicoAlvo.Empreendedor);
                _alunoRepositorio.Adicionar(aluno);
            }
            else
            {
                var aluno = _alunoRepositorio.ObterPorId(alunoDto.Id);
                aluno.AlterarNome(alunoDto.Nome);
            }
        }
    }
}