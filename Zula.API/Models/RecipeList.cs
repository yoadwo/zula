using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Zula.API.Models
{
    public class RecipeList
    {
        [JsonPropertyName("results")]
        public IEnumerable<Recipe> Results { get; set; }
    }
}
