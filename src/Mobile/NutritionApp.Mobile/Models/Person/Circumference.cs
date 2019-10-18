using Newtonsoft.Json;
using System;

namespace NutritionApp.Mobile.Models.Person
{
    public class Circumference
    {
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("Neck")]
        public double Neck { get; set; }

        [JsonProperty("Chest")]
        public double Chest { get; set; }

        [JsonProperty("UpperArmLeft")]
        public double UpperArmLeft { get; set; }

        [JsonProperty("UpperArmRight")]
        public double UpperArmRight { get; set; }

        [JsonProperty("UnderArmLeft")]
        public double UnderArmLeft { get; set; }

        [JsonProperty("UnderArmRight")]
        public double UnderArmRight { get; set; }

        [JsonProperty("Waist")]
        public double Waist { get; set; }

        [JsonProperty("Belly")]
        public double Belly { get; set; }

        [JsonProperty("Hip")]
        public double Hip { get; set; }

        [JsonProperty("LegLeft")]
        public double LegLeft { get; set; }

        [JsonProperty("LegRight")]
        public double LegRight { get; set; }

        [JsonProperty("CalfLeft")]
        public double CalfLeft { get; set; }

        [JsonProperty("CalfRight")]
        public double CalfRight { get; set; }

        #region Constructors

        public Circumference()
        {

        }

        public Circumference(Circumference copyCircumference)
        {
            Date = copyCircumference.Date;
            Neck = copyCircumference.Neck;
            Chest = copyCircumference.Chest;
            UpperArmLeft = copyCircumference.UpperArmLeft;
            UpperArmRight = copyCircumference.UpperArmRight;
            UnderArmLeft = copyCircumference.UnderArmLeft;
            UnderArmRight = copyCircumference.UnderArmRight;
            Waist = copyCircumference.Waist;
            Belly = copyCircumference.Belly;
            Hip = copyCircumference.Hip;
            LegLeft = copyCircumference.LegLeft;
            LegRight = copyCircumference.LegRight;
            CalfLeft = copyCircumference.CalfLeft;
            CalfRight = copyCircumference.CalfRight;
        }

        public Circumference(DateTime date, double neck, double chest,
            double upperArmLeft, double upperArmRight,
            double underArmLeft, double underArmRight,
            double waist, double belly, double hip,
            double tighLeft, double tighRight,
            double calfLeft, double calfRight)
        {
            Date = date;
            Neck = neck;
            Chest = chest;
            UpperArmLeft = upperArmLeft;
            UpperArmRight = upperArmRight;
            UnderArmLeft = underArmLeft;
            UnderArmRight = underArmRight;
            Waist = waist;
            Belly = belly;
            Hip = hip;
            LegLeft = tighLeft;
            LegRight = tighRight;
            CalfLeft = calfLeft;
            CalfRight = calfRight;
        }

        #endregion
    }
}
