using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versioning.Engine
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class VersionTypeAttribute : Attribute
    {
        public VersionNumbers Version { get; set; }
    }
}
