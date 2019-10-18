using Newtonsoft.Json;
using System;

namespace NutritionApp.Mobile.Models.Nutrition
{
    public class NutritionItem
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

        public NutritionItem()
        {

        }

        public NutritionItem(NutritionItem copyNutritionItem)
        {
            ID = copyNutritionItem.ID;
            Name = copyNutritionItem.Name;
            Calories = copyNutritionItem.Calories;
            Protein = copyNutritionItem.Protein;
            Carbs = copyNutritionItem.Carbs;
            Fat = copyNutritionItem.Fat;
        }

        public NutritionItem(String name, double calories, double protein, double carbs, double fat)
        {            
            ID = Guid.NewGuid();
            Name = name;
            Calories = calories;
            Protein = protein;
            Carbs = carbs;
            Fat = fat;
        }

        #endregion
    }
}
