namespace Zula.API.AppSettings
{
    public class ApiKeys
    {        
        public SpoonacularRecipeFoodNutrition SpoonacularRecipeFoodNutrition { get; set; }        
    }

    public class SpoonacularRecipeFoodNutrition
    {
        public string Host { get; set; }
        public string Key { get; set; }
    }


}
