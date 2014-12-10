using System;
using System.Runtime.Serialization;

namespace Versioning.Engine
{
    [Serializable]
    [DataContract]
    public enum VersionNumbers
    {
        [EnumMember]
        V1 = 1,
        [EnumMember]
        V2 = 2,
        [EnumMember]
        V3 = 3
    }
}
