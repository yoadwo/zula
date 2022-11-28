using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Zula.API.Models
{
    [Table("recipes")]
    public class Recipe : IEntityNumeric
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("image")]
        [Column("image")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("missedIngredientCount")]
        public int MissedIngredientCount { get; set; }

        [JsonPropertyName("missedIngredients")]
        public IEnumerable<Ingredient> MissedIngredients {get; set;}
    }
}
