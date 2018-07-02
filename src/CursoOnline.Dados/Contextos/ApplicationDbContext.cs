using System.Threading.Tasks;
using CursoOnline.Dominio.Alunos;
using CursoOnline.Dominio.Cursos;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Dados.Contextos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
