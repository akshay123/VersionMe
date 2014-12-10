using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Versioning.Objects;
using Versioning.Engine;

namespace Version.UnitTests
{
    /// <summary>
    /// Summary description for VersionTest
    /// </summary>
    [TestClass]
    public class VersionTest
    {
        [TestMethod]
        public void ConvertToLatestVersion_Test()
        {
            var person = CommonData.PERSON1;
            var converter = new ObjectConverter();

            var latestperson = converter.UpgradeToLatestVersion<PersonWithCitizenship>(person);

            Assert.AreEqual(latestperson.PrimaryPassportCountry, "");
            Assert.AreEqual(latestperson.Name, "Joe");
            Assert.AreEqual(latestperson.PlaceOfBirth, "Timbuktu");
        }

        [TestMethod]
        public void ConvertToAnyVersion_Goes_UpgradeRoute_Test()
        {
            var person = CommonData.PERSON1;
            var converter = new ObjectConverter();

            var newerperson = converter.Convert<Person, PersonWithCitizenship>(person);

            Assert.AreEqual(newerperson.PrimaryPassportCountry, "");
            Assert.AreEqual(newerperson.Name, "Joe");
        }

        [TestMethod]
        public void ConvertToAnyVersion_Goes_DowngradeRoute_Test()
        {
            var person = CommonData.PERSON3;
            var converter = new ObjectConverter();

            var olderperson = converter.Convert<PersonWithCitizenship, Person>(person);
            Assert.AreEqual(olderperson.Name, "Joe");
        }

        [TestMethod]
        public void ConvertToAnyVersion_Test()
        {
            var person = CommonData.PERSON3;
            var converter = new ObjectConverter();

            var person2 = converter.Convert<PersonWithCitizenship, PersonWithAddress>(person);
            Assert.AreEqual(person2.Name, "Joe");
            Assert.AreEqual(person2.State, "CA");
        }

        [TestMethod]
        public void ConvertFrom_UnknowSerializedData_ToKnown_Test()
        {
            var data = CommonData.PERSONSERIALIZEDWITHOUTVERSION;

            // It was a person when it was serialized.
            dynamic someobj = Base64Serializer.DeserializeBase64<dynamic>(data); 
            var converter = new ObjectConverter();
            PersonWithCitizenship person = converter.ConvertFromDynamic<PersonWithCitizenship>(someobj);
            Assert.AreEqual(person.Name, "Joe");
            Assert.AreEqual(person.PlaceOfBirth, "Timbuktu");
        }
    }
} 
