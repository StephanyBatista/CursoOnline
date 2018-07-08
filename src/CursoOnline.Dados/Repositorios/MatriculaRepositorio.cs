using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CursoOnline.Dados.Contextos;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Matriculas;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Dados.Repositorios
{
    public class MatriculaRepositorio : RepositorioBase<Matricula>, IMatriculaRepositorio
    {
        public MatriculaRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public override List<Matricula> Consultar()
        {
            var query = Context.Set<Matricula>()
                .Include(i => i.Aluno)
                .Include(i => i.Curso)
                .ToList();

            return query;
        }
    }
}
