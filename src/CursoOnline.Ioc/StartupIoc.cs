using System;
using CursoOnline.Dados.Contextos;
using CursoOnline.Dados.Repositorios;
using CursoOnline.Dominio.Alunos;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.PublicosAlvo;
using CursoOnline.Dominio._Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CursoOnline.Dominio.Matriculas;

namespace CursoOnline.Ioc
{
    public static class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionString"]));
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped(typeof(ICursoRepositorio), typeof(CursoRepositorio));
            services.AddScoped(typeof(IAlunoRepositorio), typeof(AlunoRepositorio));
            services.AddScoped(typeof(IMatriculaRepositorio), typeof(MatriculaRepositorio));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IConversorDePublicoAlvo), typeof(ConversorDePublicoAlvo));
            services.AddScoped<ArmazenadorDeCurso>();
            services.AddScoped<ArmazenadorDeAluno>();
            services.AddScoped<CriacaoDaMatricula>();
            services.AddScoped<ConclusaoDaMatricula>();
            services.AddScoped<CancelamentoDaMatricula>();
        }
    }
}
