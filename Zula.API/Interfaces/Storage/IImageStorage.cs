using System.Threading.Tasks;
using Zula.API.Models;

namespace Zula.API.Interfaces.Storage
{
    public interface IImageStorage
    {
        /// <summary>
        /// Adds the image included in the request
        /// </summary>
        /// <param name="rant">The Rant object received from client</param>
        /// <returns>Image URI in the repo</returns>
        public string SaveRant(Recipe rant);
        public Task<System.IO.Stream> LoadRantAsync(string path);
    }
}
