using System.Collections.Generic;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Web.Util;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;

        public CursoController(ArmazenadorDeCurso armazenadorDeCurso)
        {
            _armazenadorDeCurso = armazenadorDeCurso;
        }

        public IActionResult Index()
        {
            var cursos = new List<CursoParaListagemDto>();

            return View("Index", PaginatedList<CursoParaListagemDto>.Create(cursos, Request));
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
