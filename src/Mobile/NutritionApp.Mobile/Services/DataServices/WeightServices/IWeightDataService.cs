using NutritionApp.Mobile.Services.DataService.Core;
using NutritionApp.Mobile.Models.Person;

namespace NutritionApp.Mobile.Services.DataService
{
    public interface IWeightDataService : IDataService<Weight>
    {
        /* WEIGHT */
        // Neues Gewicht hinzufügen
        // AddWeight

        // Gewicht abändern (1x Gewicht eintragen am Tag)
        // UpdateWeight

        // Gewichtseintrag löschen
        // DeleteWeight

        // Gewichtseintrag von Tag x auslesen
        // GetWeight

        // Alle Gewichtseinträge auslesen
        // GetWeights        
    }
}
