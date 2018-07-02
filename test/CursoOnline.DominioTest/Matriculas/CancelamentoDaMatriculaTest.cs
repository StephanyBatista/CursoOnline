using CursoOnline.Dominio.Matriculas;
using CursoOnline.Dominio._Base;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using Moq;
using Xunit;

namespace CursoOnline.DominioTest.Matriculas
{
    public class CancelamentoDaMatriculaTest
    {
        private readonly Mock<IMatriculaRepositorio> _matriculaRepositorio;
        private readonly CancelamentoDaMatricula _cancelamentoDaMatricula;

        public CancelamentoDaMatriculaTest()
        {
            _matriculaRepositorio = new Mock<IMatriculaRepositorio>();
            _cancelamentoDaMatricula = new CancelamentoDaMatricula(_matriculaRepositorio.Object);
        }

        [Fact]
        public void DeveCancelarMatricula()
        {
            var matricula = MatriculaBuilder.Novo().Build();
            _matriculaRepositorio.Setup(r => r.ObterPorId(matricula.Id)).Returns(matricula);

            _cancelamentoDaMatricula.Cancelar(matricula.Id);

            Assert.True(matricula.Cancelada);
        }

        [Fact]
        public void DeveNotificarQuandoMatriculaNaoEncontrada()
        {
            Matricula matriculaInvalida = null;
            const int matriculaIdInvalida = 1;
            _matriculaRepositorio.Setup(r => r.ObterPorId(It.IsAny<int>())).Returns(matriculaInvalida);

            Assert.Throws<ExcecaoDeDominio>(() =>
                    _cancelamentoDaMatricula.Cancelar(matriculaIdInvalida))
                .ComMensagem(Resource.MatriculaNaoEncontrada);
        }
    }
}
