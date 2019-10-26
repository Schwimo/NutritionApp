using NutritionApp.Core.Enums;

namespace NutritionApp.Core.Models.Nutrition
{    
    public abstract class BaseNutritionDataFormatAndValue
    {
        public double Value { get; }

        public MassUnitsEnum DataType { get; }

        public BaseNutritionDataFormatAndValue(MassUnitsEnum dataType, double value)
        {
            DataType = dataType;
            Value = value;
        }
    }

    public class NutritionDataFormatValueMicrogram : BaseNutritionDataFormatAndValue
    {
        public NutritionDataFormatValueMicrogram(double value)
             : base(MassUnitsEnum.Micrograms, value)
        {  
        }
    }

    public class NutritionDataFormatValueMilligram : BaseNutritionDataFormatAndValue
    {        
       public NutritionDataFormatValueMilligram(double value)
            : base(MassUnitsEnum.Milligrams, value)
        {
        }
    }    

    public class NutritionDataFormatValueGram : BaseNutritionDataFormatAndValue
    {
        public NutritionDataFormatValueGram(double value)
             : base(MassUnitsEnum.Grams, value)
        {
        }
    }

    public class NutritionDataFormatValueKilogram : BaseNutritionDataFormatAndValue
    {
        public NutritionDataFormatValueKilogram(double value)
             : base(MassUnitsEnum.Kilograms, value)
        {
        }
    }
}