using System;
using CursoOnline.Dominio._Base;

namespace CursoOnline.Dominio.Cursos
{
    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            var cursoJaSalvo = _cursoRepositorio.ObterPeloNome(cursoDto.Nome);

            ValidadorDeRegra.Novo()
                .Quando(cursoJaSalvo != null && cursoJaSalvo.Id != cursoDto.Id, Resource.NomeDoCursoJaExiste)
                .Quando(!Enum.TryParse<PublicoAlvo>(cursoDto.PublicoAlvo, out var publicoAlvo), Resource.PublicoAlvoInvalido)
                .DispararExcecaoSeExistir();
                
            var curso = 
                new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, publicoAlvo, cursoDto.Valor);

            if (cursoDto.Id > 0)
            {
                curso = _cursoRepositorio.ObterPorId(cursoDto.Id);
                curso.AlterarNome(cursoDto.Nome);
                curso.AlterarValor(cursoDto.Valor);
                curso.AlterarCargaHoraria(cursoDto.CargaHoraria);
            }

            if(cursoDto.Id == 0)
                _cursoRepositorio.Adicionar(curso);
        }
    }
}