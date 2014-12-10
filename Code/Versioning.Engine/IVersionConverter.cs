using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versioning.Engine
{
    /// <summary>
    /// Specifies version compatibility.
    /// </summary>
    /// <remarks>
    /// It is required <see cref="TDowngradeTo"/> object to have implementing <see cref="IVersionConverter{TDowngradeTo,TUpgradeTo}"/>
    /// It is also required <see cref="TUpgradeTo"/> object to have implementing <see cref="IVersionConverter{TDowngradeTo,TUpgradeTo}"/>
    /// Implementing class will call the <see cref="Downgrade"/> or call <see cref="Upgrade"/>
    /// </remarks>
    /// <typeparam name="TDowngradeTo">Class or DTO to downgrade to</typeparam>
    /// <typeparam name="TUpgradeTo">Class or DTO to upgrade to</typeparam>
    public interface IVersionConverter<out TDowngradeTo, out TUpgradeTo>
    {
        /// <summary>
        /// Downgrade the existing version to lower version
        /// </summary>
        /// <returns>Downgraded versioned object</returns>
        TDowngradeTo Downgrade();

        /// <summary>
        /// Upgrade the existing version to higher version
        /// </summary>
        /// <returns>Upgraded versioned object</returns>
        TUpgradeTo Upgrade();
    }
}
