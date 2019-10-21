using NutritionApp.Mobile.Models.Nutrition;
using NutritionApp.Mobile.Services.DataService.Core;

namespace NutritionApp.Mobile.Services.DataService
{
    public interface IRecipeDataService : IDataService<RecipeItem>
    {        
        /* RECIPIE ENTRIES */
        // Neues Rezept hinzufügen
        // AddRecipe

        // Rezept abändern
        // UpdateRecipe

        // Rezept löschen
        // DeleteRecipe

        // Rezept auslesen by ID
        // GetRecipe

        // Alle Rezepte auslesen
        // GetRecipes
    }
}
