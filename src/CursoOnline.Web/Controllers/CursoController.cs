using System.Collections.Generic;
using System.Linq;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio._Base;
using CursoOnline.Web.Util;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        private readonly IRepositorio<Curso> _cursoRepositorio;

        public CursoController(ArmazenadorDeCurso armazenadorDeCurso, IRepositorio<Curso> cursoRepositorio)
        {
            _armazenadorDeCurso = armazenadorDeCurso;
            _cursoRepositorio = cursoRepositorio;
        }

        public IActionResult Index()
        {
            var cursos = _cursoRepositorio.Consultar();

            if (cursos.Any())
            {
                var dtos = cursos.Select(c => new CursoParaListagemDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    CargaHoraria = c.CargaHoraria,
                    PublicoAlvo = c.PublicoAlvo.ToString(),
                    Valor = c.Valor
                });
                return View("Index", PaginatedList<CursoParaListagemDto>.Create(dtos, Request));
            }

            return View("Index", PaginatedList<CursoParaListagemDto>.Create(null, Request));
        }

        public IActionResult Editar(int id)
        {
            var curso = _cursoRepositorio.ObterPorId(id);
            var dto = new CursoDto
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Descricao = curso.Descricao,
                CargaHoraria = curso.CargaHoraria,
                Valor = curso.Valor
            };

            return View("NovoOuEditar", dto);
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar", new CursoDto());
        }

        [HttpPost]
        public IActionResult Salvar(CursoDto model)
        {
            _armazenadorDeCurso.Armazenar(model);

            return Ok();
        }
    }
}
