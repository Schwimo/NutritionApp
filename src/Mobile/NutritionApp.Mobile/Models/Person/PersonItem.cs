using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NutritionApp.Mobile.Models.Person
{
    public class PersonItem
    {
        [JsonProperty("Id")]
        public string PersonId { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("FamilyName")]
        public string FamilyName { get; set; }

        [JsonProperty("MailAddress")]
        public string MailAddress { get; set; }

        [JsonProperty("Birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty("Height")]
        public double Height { get; set; }

        [JsonProperty("Weights")]
        public IList<Weight> Weights { get; set; }

        [JsonProperty("Circumferences")]
        public IList<Circumference> Circumferences { get; set; }

        #region Constructors

        public PersonItem()
        {

        }

        public PersonItem(PersonItem copyPerson)
        {
            PersonId = copyPerson.PersonId;
            FirstName = copyPerson.FirstName;
            FamilyName = copyPerson.FamilyName;
            MailAddress = copyPerson.MailAddress;
            Birthday = copyPerson.Birthday;
            Height = copyPerson.Height;
            Weights = copyPerson.Weights;
            Circumferences = copyPerson.Circumferences;
        }

        public PersonItem(string personId, string firstName, string familyName, string mailAddress, DateTime birthday, double height, IList<Weight> weights, IList<Circumference> circumferences)
        {
            PersonId = personId ?? throw new ArgumentNullException(nameof(personId));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            FamilyName = familyName;
            MailAddress = mailAddress;
            Birthday = birthday;
            Height = height;
            Weights = weights;
            Circumferences = circumferences;
        }

        #endregion
    }
}
