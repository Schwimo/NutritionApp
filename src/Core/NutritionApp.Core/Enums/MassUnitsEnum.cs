using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NutritionApp.Core.Enums
{
    public enum MassUnitsEnum
    {
        [Description("kg")]
        Kilograms,

        [Description("g")]
        Grams,

        [Description("mg")]
        Milligrams,

        [Description("yg")]
        Micrograms,
    }
}
