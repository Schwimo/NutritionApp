using System.ComponentModel;

namespace NutritionApp.Mobile.Enums
{
    public enum BodyPartEnum
    {
        [Description("")]
        NONE,

        [Description("WEIGHT")]
        WEIGHT,

        [Description("NECK")]
        NECK,

        [Description("CHEST")]
        CHEST,

        [Description("LEFT UPPER ARM")]
        LEFT_UPPER_ARM,

        [Description("RIGHT UPPER ARM")]
        RIGHT_UPPER_ARM,

        [Description("BELLY")]
        BELLY,

        [Description("HIP")]
        HIP,

        [Description("LEFT UNDER ARM")]
        LEFT_UNDER_ARM,

        [Description("RIGHT UNDER ARM")]
        RIGHT_UNDER_ARM,

        [Description("LEFT LEG")]
        LEFT_LEG,

        [Description("RIGHT LEG")]
        RIGHT_LEG,

        [Description("LEFT CALF")]
        LEFT_CALF,

        [Description("RIGHT CALF")]
        RIGHT_CALF
    }
}
