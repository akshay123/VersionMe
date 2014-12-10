using System;
using Versioning.Engine;

namespace Versioning.Objects
{
     [VersionType(Version = VersionNumbers.V3)]
    public class PersonWithCitizenship : IPersonWithCitizenship, IVersionConverter<IPersonWithAddress, object>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string[] CountriesOfCitizenship { get; set; }
        public string PrimaryPassportCountry { get; set; }


        public IPersonWithAddress Downgrade()
        {
            return new PersonWithAddress
            {
                City = this.City,
                Country = this.Country,
                DateOfBirth = this.DateOfBirth,
                Name = this.Name,
                PlaceOfBirth = this.PlaceOfBirth,
                State = this.State,
                StreetAddress = this.StreetAddress,
                ZipCode = this.ZipCode
            };
        }

        public object Upgrade()
        {
            return null;
        }
      
    }
}
