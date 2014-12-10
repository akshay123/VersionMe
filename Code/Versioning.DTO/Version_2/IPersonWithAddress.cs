using System;
using Versioning.Engine;

namespace Versioning.Objects
{
    public interface IPersonWithAddress:IPerson
    {
        string StreetAddress { get; set; }
        string City { get; set; }
        string State { get; set; }

        string Country { get; set; }

        string ZipCode { get; set; }      
    }
}
