using Newtonsoft.Json;
using System;

namespace NutritionApp.Core.Models.Nutrition
{
    public class RecipeItem
    {
        [JsonProperty("ID")]
        public Guid ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Calories")]
        public double Calories { get; set; }

        [JsonProperty("Protein")]
        public double Protein { get; set; }

        [JsonProperty("Carbs")]
        public double Carbs { get; set; }

        [JsonProperty("Fat")]
        public double Fat { get; set; }

        #region Constructors

        public RecipeItem()
        {

        }        

        #endregion
    }
}
