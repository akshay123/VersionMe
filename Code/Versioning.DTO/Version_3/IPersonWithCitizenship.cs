using System;
using Versioning.Engine;

namespace Versioning.Objects
{
    public interface IPersonWithCitizenship : IPersonWithAddress
    {
         string [] CountriesOfCitizenship { get; set; }
         string PrimaryPassportCountry { get; set; }
    }
}
