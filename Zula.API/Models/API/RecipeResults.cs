using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Zula.API.Models
{
    public class RecipeResults
    {
        [JsonPropertyName("results")]
        public IEnumerable<Recipe> Results { get; set; }
    }
}
