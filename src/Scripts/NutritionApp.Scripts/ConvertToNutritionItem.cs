using NutritionApp.Core.Models.Nutrition;
using System;
using System.Data;

namespace NutritionApp.Scripts
{
    public static class ConvertToNutritionItem
    {
        public static NutritionItem ConvertRow(DataRow header, DataRow row)
        {
            NutritionItem nutriItem = new NutritionItem();

            for (int i = 0; i < row.ItemArray.Length; i++)
            {
                if (header.ItemArray[i].Equals("ID"))
                {   
                    nutriItem.ID = Convert.ToInt32(row.ItemArray[i]);
                }
                else if (header.ItemArray[i].Equals("Name"))
                {
                    nutriItem.Name = row.ItemArray[i].ToString();
                }
                else if (header.ItemArray[i].Equals("Synonyme"))
                {                    
                    nutriItem.Synonyms = row.ItemArray[i].ToString().Split(';');
                }
                else if (header.ItemArray[i].Equals("Kategorie"))
                {
                    nutriItem.Categories = row.ItemArray[i].ToString().Split(';');
                }
                else if (header.ItemArray[i].Equals("Bezugseinheit"))
                {
                    if (row.ItemArray[i].ToString().Equals("pro 100 ml"))
                    {
                        nutriItem.ReferenceValue = Core.Enums.ReferenceUnitsEnum.Milliliters;
                    }
                    else if (row.ItemArray[i].ToString().Equals("pro 100g essbarer Anteil"))
                    {
                        nutriItem.ReferenceValue = Core.Enums.ReferenceUnitsEnum.Grams;
                    }                    
                }
                else if (header.ItemArray[i].Equals("Energie, Kilojoule"))
                {
                    nutriItem.KiloJoule = Convert.ToDouble(row.ItemArray[i]);
                }
                else if (header.ItemArray[i].Equals("Energie, Kalorien"))
                {
                    nutriItem.Calories = Convert.ToDouble(row.ItemArray[i]);
                }
                else if (header.ItemArray[i].Equals("Fett, total (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Fat = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.Fat = new NutritionDataFormatValueGram(0.0);
                    }                    
                }
                else if (header.ItemArray[i].Equals("Fettsäuren, gesättigt (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.FattyAcidsSaturated = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.FattyAcidsSaturated = new NutritionDataFormatValueGram(0.0);
                    }                    
                }
                else if (header.ItemArray[i].Equals("Fettsäuren, einfach ungesättigt (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.FattyAcidsSingleSaturated = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.FattyAcidsSingleSaturated = new NutritionDataFormatValueGram(0.0);
                    }                                      
                }
                else if (header.ItemArray[i].Equals("Fettsäuren, mehrfach ungesättigt (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.FattyAcidsMultiSaturated = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.FattyAcidsMultiSaturated = new NutritionDataFormatValueGram(0.0);
                    }                    
                }
                else if (header.ItemArray[i].Equals("Cholesterin (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Cholesterol = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.Cholesterol = new NutritionDataFormatValueMilligram(0.0);
                    }                    
                }
                else if (header.ItemArray[i].Equals("Kohlenhydrate, verfügbar (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Carbs = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.Carbs = new NutritionDataFormatValueGram(0.0);
                    }                    
                }
                else if (header.ItemArray[i].Equals("Zucker (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Sugar = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.Sugar = new NutritionDataFormatValueGram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Stärke (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Starch = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.Starch = new NutritionDataFormatValueGram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Nahrungsfasern (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Fibres = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.Fibres = new NutritionDataFormatValueGram(0.0);
                    }                    
                }
                else if (header.ItemArray[i].Equals("Protein (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Protein = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.Protein = new NutritionDataFormatValueGram(0.0);
                    }                    
                }
                else if (header.ItemArray[i].Equals("Salz (NaCl) (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Salt = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.Salt = new NutritionDataFormatValueGram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Alkohol (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Alcohol = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.Alcohol = new NutritionDataFormatValueGram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Wasser (g)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Water = new NutritionDataFormatValueGram(outValue);
                    }
                    else
                    {
                        nutriItem.Water = new NutritionDataFormatValueGram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Vitamin A-Aktivität, RE (µg-RE)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.VitaminA_RE = new NutritionDataFormatValueMicrogram(outValue);
                    }
                    else
                    {
                        nutriItem.VitaminA_RE = new NutritionDataFormatValueMicrogram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Vitamin A-Aktivität, RAE (µg-RE)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.VitaminA_RAE = new NutritionDataFormatValueMicrogram(outValue);
                    }
                    else
                    {
                        nutriItem.VitaminA_RAE = new NutritionDataFormatValueMicrogram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("All-trans Retinol-Äquivalente (µg-RE)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Retinol = new NutritionDataFormatValueMicrogram(outValue);
                    }
                    else
                    {
                        nutriItem.Retinol = new NutritionDataFormatValueMicrogram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Betacarotin-Aktivität (µg-BCE)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.BetacarotinActivity = new NutritionDataFormatValueMicrogram(outValue);
                    }
                    else
                    {
                        nutriItem.BetacarotinActivity = new NutritionDataFormatValueMicrogram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Betacarotin (µg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Betacarotin = new NutritionDataFormatValueMicrogram(outValue);
                    }
                    else
                    {
                        nutriItem.Betacarotin = new NutritionDataFormatValueMicrogram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Vitamin B1 (Thiamin) (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.VitaminB1 = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.VitaminB1 = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Vitamin B2 (Riboflavin) (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.VitaminB2 = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.VitaminB2 = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Vitamin B6 (Pyridoxin) (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.VitaminB6 = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.VitaminB6 = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Vitamin B12 (Cobalamin) (µg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.VitaminB12 = new NutritionDataFormatValueMicrogram(outValue);
                    }
                    else
                    {
                        nutriItem.VitaminB12 = new NutritionDataFormatValueMicrogram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Niacin (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Niacin = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.Niacin = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Folat (µg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Folat = new NutritionDataFormatValueMicrogram(outValue);
                    }
                    else
                    {
                        nutriItem.Folat = new NutritionDataFormatValueMicrogram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Pantothensäure (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.PantothenicAcid = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.PantothenicAcid = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Vitamin C (Ascorbinsäure) (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.VitaminC = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.VitaminC = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Vitamin D (Calciferol) (µg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.VitaminD = new NutritionDataFormatValueMicrogram(outValue);
                    }
                    else
                    {
                        nutriItem.VitaminD = new NutritionDataFormatValueMicrogram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Vitamin E-Aktivität (mg-ATE)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.VitaminE = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.VitaminE = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Kalium (K) (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Potassium = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.Potassium = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Natrium (Na) (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Sodium = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.Sodium = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Chlorid (Cl) (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Chlorid = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.Chlorid = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Calcium (Ca) (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Calcium = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.Calcium = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Magnesium (Mg) (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Magnesium = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.Magnesium = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Phosphor (P) (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Phosphorus = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.Phosphorus = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Eisen (Fe) (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Iron = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.Iron = new NutritionDataFormatValueMilligram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Jod (I) (µg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Iodine = new NutritionDataFormatValueMicrogram(outValue);
                    }
                    else
                    {
                        nutriItem.Iodine = new NutritionDataFormatValueMicrogram(0.0);
                    }
                }
                else if (header.ItemArray[i].Equals("Zink (Zn)  (mg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Zinc = new NutritionDataFormatValueMilligram(outValue);
                    }
                    else
                    {
                        nutriItem.Zinc = new NutritionDataFormatValueMilligram(0.0);
                    }          
                }
                else if (header.ItemArray[i].Equals("Selen (Se) (µg)"))
                {
                    if (Double.TryParse(row.ItemArray[i].ToString(), out double outValue))
                    {
                        nutriItem.Selenium = new NutritionDataFormatValueMicrogram(outValue);
                    }
                    else
                    {
                        nutriItem.Selenium = new NutritionDataFormatValueMicrogram(0.0);
                    }
                }
            }

            return nutriItem;
        }
    }
}
