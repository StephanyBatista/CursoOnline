using System.Linq;
using CursoOnline.Dados.Contextos;
using CursoOnline.Dominio.Alunos;

namespace CursoOnline.Dados.Repositorios
{
    public class AlunoRepositorio : RepositorioBase<Aluno>, IAlunoRepositorio
    {
        public AlunoRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public Aluno ObterPeloCpf(string cpf)
        {
            var alunos = Context.Set<Aluno>().Where(a => a.Cpf == cpf);
            return alunos.Any() ? alunos.First() : null;
        }
    }
}
