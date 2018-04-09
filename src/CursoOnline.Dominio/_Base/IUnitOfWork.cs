using System.Threading.Tasks;

namespace CursoOnline.Dominio._Base
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
