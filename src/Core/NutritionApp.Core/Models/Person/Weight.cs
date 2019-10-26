using Newtonsoft.Json;
using System;

namespace NutritionApp.Core.Models.Person
{
    public class Weight
    {
        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        #region Constructors

        public Weight()
        {

        }

        public Weight(Weight copyWeight)
        {
            Value = copyWeight.Value;
            Date = copyWeight.Date;
        }

        public Weight(double value, DateTime date)
        {
            Value = value;
            Date = date;
        }

        #endregion
    }
}
