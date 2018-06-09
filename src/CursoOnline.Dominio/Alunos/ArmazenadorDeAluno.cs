using CursoOnline.Dominio.PublicosAlvo;
using CursoOnline.Dominio._Base;

namespace CursoOnline.Dominio.Alunos
{
    public class ArmazenadorDeAluno
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IConversorDePublicoAlvo _conversorDePublicoAlvo;

        public ArmazenadorDeAluno(IAlunoRepositorio alunoRepositorio, IConversorDePublicoAlvo conversorDePublicoAlvo)
        {
            _alunoRepositorio = alunoRepositorio;
            _conversorDePublicoAlvo = conversorDePublicoAlvo;
        }

        public void Armazenar(AlunoDto alunoDto)
        {
            var alunoComMesmoCpf = _alunoRepositorio.ObterPeloCpf(alunoDto.Cpf);

            ValidadorDeRegra.Novo()
                .Quando(alunoComMesmoCpf != null && alunoComMesmoCpf.Id != alunoDto.Id, Resource.CpfJaCadastrado)
                .DispararExcecaoSeExistir();

            if (alunoDto.Id == 0)
            {
                var publicoAlvoConvertido = _conversorDePublicoAlvo.Converter(alunoDto.PublicoAlvo);
                var aluno = new Aluno(alunoDto.Nome, alunoDto.Email, alunoDto.Cpf, publicoAlvoConvertido);
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