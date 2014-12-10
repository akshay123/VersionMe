using System;
using Versioning.Engine;

namespace Versioning.Objects
{
    [Serializable]
    [VersionType(Version = VersionNumbers.V1)]
    public class Person:IPerson, IVersionConverter<object, IPersonWithAddress>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

    
        public object Downgrade()
        {
 	        return null;
        }

        public IPersonWithAddress Upgrade()
        {
 	        return new PersonWithAddress 
            {
                Name = this.Name,
                DateOfBirth = this.DateOfBirth,
                PlaceOfBirth = this.PlaceOfBirth,
                StreetAddress = String.Empty,
                City = String.Empty,                
                State = String.Empty,
                Country = String.Empty

            };
        }
}
}
