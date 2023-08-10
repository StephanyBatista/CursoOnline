using CursoOnline.Dominio._Base;

namespace CursoOnline.Dominio.Matriculas
{
    public class CancelamentoDaMatricula
    {
        private readonly IMatriculaRepositorio _matriculaRepositorio;

        public CancelamentoDaMatricula(IMatriculaRepositorio matriculaRepositorio)
        {
            _matriculaRepositorio = matriculaRepositorio;
        }

        public void Cancelar(int matriculaId)
        {
            var matricula = _matriculaRepositorio.ObterPorId(matriculaId);

            ValidadorDeRegra.Novo()
                .Quando(matricula == null, Resource.MatriculaNaoEncontrada)
                .DispararExcecaoSeExistir();

            matricula.Cancelar();
        }
    }
}