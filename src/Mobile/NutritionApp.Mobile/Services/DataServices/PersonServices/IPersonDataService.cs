using NutritionApp.Core.Models.Person;
using NutritionApp.Mobile.Services.DataService.Core;

namespace NutritionApp.Mobile.Services.DataService
{
    public interface IPersonDataService : IDataService<PersonItem>
    {
        /* PERSON */
        // Neue Person erstellen
        // AddPersonItem 

        // Person updaten, keine Ahnung was, könnte man aber brauchen
        // UpdatePersonItem

        // Person löscht Account
        // DeletePersonItem        
    }
}
