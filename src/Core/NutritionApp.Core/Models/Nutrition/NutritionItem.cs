using Newtonsoft.Json;
using NutritionApp.Core.Enums;
using System;
using System.Collections.Generic;

namespace NutritionApp.Core.Models.Nutrition
{
    public class NutritionItem
    {
        #region Properties

        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Synonyms")]
        public IEnumerable<string> Synonyms { get; set; }

        [JsonProperty("Categories")]
        public IEnumerable<string> Categories { get; set; }

        [JsonProperty("ReferenceValue")]
        public ReferenceUnitsEnum ReferenceValue { get; set; }

        [JsonProperty("Kilojoule")]
        public double KiloJoule { get; set; }
        
        [JsonProperty("Calories")]
        public double Calories { get; set; }

        [JsonProperty("Fat")]
        public NutritionDataFormatValueGram Fat { get; set; }

        [JsonProperty("FattyAcidsSaturated")]
        public NutritionDataFormatValueGram FattyAcidsSaturated { get; set; }

        [JsonProperty("FattyAcidsSingleSaturated")]
        public NutritionDataFormatValueGram FattyAcidsSingleSaturated { get; set; }

        [JsonProperty("FattyAcidsMultiSaturated")]
        public NutritionDataFormatValueGram FattyAcidsMultiSaturated { get; set; }

        [JsonProperty("Cholesterol")]
        public NutritionDataFormatValueMilligram Cholesterol { get; set; }

        [JsonProperty("Carbs")]
        public NutritionDataFormatValueGram Carbs { get; set; }

        [JsonProperty("Sugar")]
        public NutritionDataFormatValueGram Sugar { get; set; }

        [JsonProperty("Starch")]
        public NutritionDataFormatValueGram Starch { get; set; }

        [JsonProperty("Fibres")]
        public NutritionDataFormatValueGram Fibres { get; set; }

        [JsonProperty("Protein")]
        public NutritionDataFormatValueGram Protein { get; set; }

        [JsonProperty("Salt")]
        public NutritionDataFormatValueGram Salt { get; set; }

        [JsonProperty("Alcohol")]
        public NutritionDataFormatValueGram Alcohol { get; set; }

        [JsonProperty("Water")]
        public NutritionDataFormatValueGram Water { get; set; }

        [JsonProperty("VitaminA_RE")]
        public NutritionDataFormatValueMicrogram VitaminA_RE { get; set; }

        [JsonProperty("VitaminA_RAE")]
        public NutritionDataFormatValueMicrogram VitaminA_RAE { get; set; }

        [JsonProperty("Retinol")]
        public NutritionDataFormatValueMicrogram Retinol { get; set; }

        [JsonProperty("BetacarotinActivity")]
        public NutritionDataFormatValueMicrogram BetacarotinActivity { get; set; }

        [JsonProperty("Betacarotin")]
        public NutritionDataFormatValueMicrogram Betacarotin { get; set; }

        [JsonProperty("VitaminB1")]
        public NutritionDataFormatValueMilligram VitaminB1 { get; set; }

        [JsonProperty("VitaminB2")]
        public NutritionDataFormatValueMilligram VitaminB2 { get; set; }

        [JsonProperty("VitaminB6")]
        public NutritionDataFormatValueMilligram VitaminB6 { get; set; }

        [JsonProperty("VitaminB12")]
        public NutritionDataFormatValueMicrogram VitaminB12 { get; set; }

        [JsonProperty("Niacin")]
        public NutritionDataFormatValueMilligram Niacin { get; set; }

        [JsonProperty("Folat")]
        public NutritionDataFormatValueMicrogram Folat { get; set; }

        [JsonProperty("PantothenicAcid")]
        public NutritionDataFormatValueMilligram PantothenicAcid { get; set; }

        [JsonProperty("VitaminC")]
        public NutritionDataFormatValueMilligram VitaminC { get; set; }

        [JsonProperty("VitaminD")]
        public NutritionDataFormatValueMicrogram VitaminD { get; set; }

        [JsonProperty("VitaminE")]
        public NutritionDataFormatValueMilligram VitaminE { get; set; }

        [JsonProperty("Potassium")]
        public NutritionDataFormatValueMilligram Potassium { get; set; }

        [JsonProperty("Sodium")]
        public NutritionDataFormatValueMilligram Sodium { get; set; }

        [JsonProperty("Chlorid")]
        public NutritionDataFormatValueMilligram Chlorid { get; set; }

        [JsonProperty("Calcium")]
        public NutritionDataFormatValueMilligram Calcium { get; set; }

        [JsonProperty("Magnesium")]
        public NutritionDataFormatValueMilligram Magnesium { get; set; }

        [JsonProperty("Phosphorus")]
        public NutritionDataFormatValueMilligram Phosphorus { get; set; }

        [JsonProperty("Iron")]
        public NutritionDataFormatValueMilligram Iron { get; set; }

        [JsonProperty("Iodine")]
        public NutritionDataFormatValueMicrogram Iodine { get; set; }

        [JsonProperty("Zinc")]
        public NutritionDataFormatValueMilligram Zinc { get; set; }

        [JsonProperty("Selenium")]
        public NutritionDataFormatValueMicrogram Selenium { get; set; }

        #endregion

        #region Constructors

        public NutritionItem()
        {

        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"ID: {ID} NAME: {Name} KH: {Carbs.Value} F: {Fat.Value} P: {Protein.Value}";
        }

        #endregion
    }
}
