using System;
using Versioning.Engine;

namespace Versioning.Objects
{
     [VersionType(Version = VersionNumbers.V2)]
    public class PersonWithAddress : IPersonWithAddress, IVersionConverter<IPerson, IPersonWithCitizenship>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
       
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public IPerson Downgrade()
        {
            return new Person { DateOfBirth = this.DateOfBirth, PlaceOfBirth = this.PlaceOfBirth, Name = this.Name };
        }
     
        public IPersonWithCitizenship Upgrade()
        {
            return new PersonWithCitizenship
            {
                City = this.City,
                Country = this.Country,
                DateOfBirth = this.DateOfBirth,
                Name = this.Name,
                PlaceOfBirth = this.PlaceOfBirth,
                State = this.State,
                StreetAddress = this.StreetAddress,
                ZipCode = this.ZipCode,
                PrimaryPassportCountry = String.Empty,
                CountriesOfCitizenship = null
            };
        }
    }
}
