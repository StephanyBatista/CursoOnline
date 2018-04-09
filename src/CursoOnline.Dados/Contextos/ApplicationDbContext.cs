using System;
using System.Threading.Tasks;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio._Base;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Dados.Contextos
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
