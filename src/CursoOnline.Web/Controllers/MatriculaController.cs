using System.Linq;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Matriculas;
using CursoOnline.Dominio._Base;
using CursoOnline.Web.Util;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Web.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly CriacaoDaMatricula _criacaoDaMatricula;
        private readonly IRepositorio<Matricula> _matriculaRepositorio;

        public MatriculaController(CriacaoDaMatricula criacaoDaMatricula, IRepositorio<Matricula> matriculaRepositorio)
        {
            _criacaoDaMatricula = criacaoDaMatricula;
            _matriculaRepositorio = matriculaRepositorio;
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

            return View("Index", PaginatedList<CursoParaListagemDto>.Create(null, Request));
        }

        public IActionResult Novo()
        {
            return View("Nova", new MatriculaDto());
        }

        [HttpPost]
        public IActionResult Salvar(MatriculaDto model)
        {
            _criacaoDaMatricula.Criar(model);

            return Ok();
        }
    }
}
