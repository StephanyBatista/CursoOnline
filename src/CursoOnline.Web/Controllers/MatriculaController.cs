using System.Linq;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Matriculas;
using CursoOnline.Dominio._Base;
using CursoOnline.Web.Util;
using Microsoft.AspNetCore.Mvc;
using CursoOnline.Dominio.Alunos;

namespace CursoOnline.Web.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly CriacaoDaMatricula _criacaoDaMatricula;
        private readonly IRepositorio<Matricula> _matriculaRepositorio;
        private readonly IRepositorio<Aluno> _alunoRepositorio;
        private readonly IRepositorio<Curso> _cursoRepositorio;

        public MatriculaController(
            CriacaoDaMatricula criacaoDaMatricula, 
            IRepositorio<Matricula> matriculaRepositorio,
            IRepositorio<Aluno> alunoRepositorio,
            IRepositorio<Curso> cursoRepositorio)
        {
            _criacaoDaMatricula = criacaoDaMatricula;
            _matriculaRepositorio = matriculaRepositorio;
            _alunoRepositorio = alunoRepositorio;
            _cursoRepositorio = cursoRepositorio;
        }

        public IActionResult Index()
        {
            var matriculas = _matriculaRepositorio.Consultar();

            if (matriculas.Any())
            {
                var dtos = matriculas.Where(m => !m.Cancelada).Select(c => new MatriculaParaListagemDto
                {
                    Id = c.Id,
                    NomeDoAluno = c.Aluno.Nome,
                    NomeDoCurso = c.Curso.Nome,
                    Valor = c.ValorPago
                });
                return View("Index", PaginatedList<MatriculaParaListagemDto>.Create(dtos, Request));
            }

            return View("Index", PaginatedList<MatriculaParaListagemDto>.Create(null, Request));
        }

        public IActionResult Novo()
        {
            InicializarAlunosECursosNaViewBag();

            return View("Nova", new MatriculaDto());
        }

        private void InicializarAlunosECursosNaViewBag()
        {
            var alunos = _alunoRepositorio.Consultar();
            if (alunos != null && alunos.Any())
                alunos = alunos.OrderBy(a => a.Nome).ToList();

            ViewBag.Alunos = alunos;

            var cursos = _cursoRepositorio.Consultar();
            if (cursos != null && cursos.Any())
                cursos = cursos.OrderBy(c => c.Nome).ToList();

            ViewBag.Cursos = cursos;
        }

        [HttpPost]
        public IActionResult Salvar(MatriculaDto model)
        {
            _criacaoDaMatricula.Criar(model);

            return Ok();
        }
    }
}
