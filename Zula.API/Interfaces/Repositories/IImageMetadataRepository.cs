using System.Threading.Tasks;
using Zula.API.Models;

namespace Zula.API.Interfaces.Repositories.ImageMetadataRepository
{
    public interface IImageMetadataRepository : IGenericRepository<Recipe>
    {
        public Recipe AddRant(Recipe recipe, string fileRelativePath);
    }
}
