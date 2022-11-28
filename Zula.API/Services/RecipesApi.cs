using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Zula.API.Models;

namespace Zula.API.Services
{
    public class RecipesApi : Interfaces.ExternalApis.IRecipesApi
    {
		private readonly Interfaces.Services.IHttpClient _httpClient;
		private readonly IOptions<AppSettings.ApiKeys> _apiKeysOptions;
		private readonly Dictionary<string, string> headers;

		public RecipesApi(Interfaces.Services.IHttpClient httpClient, IOptions<AppSettings.ApiKeys> apiKeysOptions)
        {
			_httpClient = httpClient;
			_apiKeysOptions = apiKeysOptions;

			headers = new Dictionary<string, string>()
			{
				{ "X-RapidAPI-Host", _apiKeysOptions.Value.SpoonacularRecipeFoodNutrition.Host },
				{ "X-RapidAPI-Key", _apiKeysOptions.Value.SpoonacularRecipeFoodNutrition.Key },
			};			
		}

		public async Task<IEnumerable<Recipe>> GetAllRecipesAsync(string query)
		{
			var queryBuilder = new QueryBuilder();
			queryBuilder.Add("limitLicense", "false");
			queryBuilder.Add("instructionsRequired", "true");
			queryBuilder.Add("addRecipeInformation", "false");
			queryBuilder.Add("fillIngredients", "true");
			queryBuilder.Add("ranking", "2");
			queryBuilder.Add("query", query);
			string queryParams = queryBuilder.ToQueryString().Value;

			var response = await _httpClient.SendHttpRequestAsync<RecipeList>(
				HttpMethod.Get,
				"https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/complexSearch",
				queryParams,
				headers);
			// until a better logic is determined,
			// just take the one with most ingredients
			var missed = response.Results.Aggregate((agg, next) =>
			next.MissedIngredientCount > agg.MissedIngredientCount ? next : agg);
			return response.Results;
		}
    }
}
