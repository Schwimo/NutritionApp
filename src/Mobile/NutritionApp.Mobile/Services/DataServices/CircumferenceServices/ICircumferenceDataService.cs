using NutritionApp.Mobile.Models.Person;
using NutritionApp.Mobile.Services.DataService.Core;

namespace NutritionApp.Mobile.Services.DataService
{
    public interface ICircumferenceDataService : IDataService<Circumference>
    {        
        /* CIRCUMFERENCE */
        // Neues Maß hinzufügen
        // AddCircumference

        // Maß abändern (1x Maß eintragen pro Tag)
        // UpdateCircumference

        // Maßeintrag löschen
        // DeleteCircumference

        // Maßseintrag von Tag x auslesen
        // GetCircumference

        // Alle Maßeinträge auslesen
        // GetCircumferences
    }
}
