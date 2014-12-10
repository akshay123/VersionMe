using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versioning.Objects;

namespace Version.UnitTests
{
    public static class CommonData
    {
        // Serialized data for person.
        public static readonly string PERSONSERIALIZEDWITHOUTVERSION  = "256:AAEAAAD/////AQAAAAAAAAAMAgAAAElWZXJzaW9uaW5nLk9iamVjdHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsBQEAAAAZVmVyc2lvbmluZy5PYmplY3RzLlBlcnNvbgMAAAAVPE5hbWU+a19fQmFja2luZ0ZpZWxkHDxEYXRlT2ZCaXJ0aD5rX19CYWNraW5nRmllbGQdPFBsYWNlT2ZCaXJ0aD5rX19CYWNraW5nRmllbGQBAAENAgAAAAYDAAAAA0pvZQBA+JlCWacIBgQAAAAIVGltYnVrdHULAAAAAA==";

        public static readonly Person                PERSON1 = new Person { DateOfBirth = DateTime.Parse("1/1/1977"), Name = "Joe", PlaceOfBirth = "Timbuktu" };
        public static readonly PersonWithAddress     PERSON2 = new PersonWithAddress { DateOfBirth = DateTime.Parse("1/1/1977"), Name = "Joe", PlaceOfBirth = "Timbuktu", StreetAddress = "123 Main Street", State = "CA", City = "San Jose", Country = "US", ZipCode = "95135" };
        public static readonly PersonWithCitizenship PERSON3 = new PersonWithCitizenship { DateOfBirth = DateTime.Parse("1/1/1977"), Name = "Joe", PlaceOfBirth = "Timbuktu", StreetAddress = "123 Main Street", State = "CA", City = "San Jose", Country = "US", ZipCode = "95135", CountriesOfCitizenship = new String[] { "US", "CAN" }, PrimaryPassportCountry = "US" };

    }
}
