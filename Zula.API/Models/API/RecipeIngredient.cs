using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Zula.API.Models
{
    public class RecipeIngredient
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        [JsonPropertyName("unit")]
        public string Unit { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("image")]
        public string ImageUrl { get; set; }
    }
}