using NutritionApp.Mobile.Models.Nutrition;
using NutritionApp.Mobile.Services.DataService.Core;

namespace NutritionApp.Mobile.Services.DataService
{
    public interface INutritionDiaryDataService : IDataService<NutritionDiaryItem>
    {
        /* NUTRITION DIARY ENTRIES */
        // Neues NutritionItem zum Tag hinzufügen
        // AddNutritionDiaryItem

        // Maß abändern (1x Maß eintragen pro Tag)
        // UpdateNutirtionDiaryItem

        // Maßeintrag löschen
        // DeleteNutritionDiaryItem

        // NutritionDiaryItem von Tag x auslesen
        // GetNutritionDiaryItem

        // Alle NutritionDiaryItems auslesen
        // GetNutritionDiaryItems        
    }
}
