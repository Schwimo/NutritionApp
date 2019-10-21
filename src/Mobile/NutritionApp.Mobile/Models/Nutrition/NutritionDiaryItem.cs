using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Mobile.Models.Nutrition
{
    public class NutritionDiaryItem
    {
        [JsonProperty("NutritionID")]
        public Guid NutritionID { get; set; }

        [JsonProperty("Amount")]
        public double Amount { get; set; }
        
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        #region Constructors

        public NutritionDiaryItem()
        {

        }

        public NutritionDiaryItem(NutritionDiaryItem copyNutritionItem)
        {
            NutritionID = copyNutritionItem.NutritionID;
            Amount = copyNutritionItem.Amount;
            Date = copyNutritionItem.Date;            
        }

        public NutritionDiaryItem(Guid nutritionId, double amount, DateTime date)
        {
            NutritionID = nutritionId;
            Amount = amount;
            Date = date;
        }

        #endregion
    }
}
