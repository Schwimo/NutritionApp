using Newtonsoft.Json;
using System.Collections.Generic;

namespace NutritionApp.Core.Models.Nutrition
{
    public class NutritionItemCategorie
    {
        #region Fields

        #endregion

        #region Properties

        [JsonProperty("ID")]
        public int ID { get; set; }
        
        [JsonProperty("ParentID")]
        public int ParentID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ListOfNutritionItemIDs")]
        public IList<int> ListOfNutritionItemIDs { get; set; }

        [JsonProperty("ListOfSubCategories")]
        public IList<NutritionItemCategorie> ListOfSubCategories { get; set; }

        #endregion

        #region Constructors

        public NutritionItemCategorie(int index)
        {
            ID = index;
            ParentID = -1;
            ListOfNutritionItemIDs = new List<int>();
            ListOfSubCategories = new List<NutritionItemCategorie>();
        }

        #endregion

        #region Methods

        #endregion
    }
}
