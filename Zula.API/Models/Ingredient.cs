using System.Text.Json.Serialization;

namespace Zula.API.Models
{
    public class Ingredient
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