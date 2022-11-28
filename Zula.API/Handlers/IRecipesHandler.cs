﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Zula.API.Models;

namespace Zula.API.Handlers
{
    public interface IRecipesHandler
    {
        public Task<Recipe> GetRecipeAsync(int id);
        public Task<IEnumerable<Recipe>> GetAllRecipesAsync(string query);
        public Task<Recipe> OnPostUploadAsync(Recipe newRecipe);
    }
}
