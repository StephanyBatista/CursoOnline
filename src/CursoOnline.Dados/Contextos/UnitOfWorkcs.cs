using CursoOnline.Dominio._Base;

namespace CursoOnline.Dados.Contextos
{
    public class UnitOfWorkcs : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWorkcs(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Commit()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
