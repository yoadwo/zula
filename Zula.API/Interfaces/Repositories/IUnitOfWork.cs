using System.Threading.Tasks;

namespace Zula.API.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IRecipeRepository Recipes { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
