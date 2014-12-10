using System;
using System.Collections.Concurrent;

namespace Versioning.Engine
{
    /// <summary>
    /// Caches versions along with type of objects passed in.
    /// </summary>
    public class VersionCache
    {
        #region Public methods
        /// <summary>
        /// Gets either cached value or gets value and caches for future.
        /// </summary>
        /// <param name="objType">use object.GetType()</param>
        /// <returns>version number</returns>
        /// <exception cref="ArgumentException">if object does not have version attribute</exception>
        public static VersionNumbers GetVersion(Type objType)
        {
            VersionNumbers versionNo;

            if (TypeVersionCache.TryGetValue(objType, out versionNo))
                return versionNo;

            versionNo = BuildVersionCache(objType);

            return versionNo;
        }

        /// <summary>
        /// Builds type wise version number cache.
        /// </summary>
        /// <param name="objType"></param>
        /// <returns></returns>
        private static VersionNumbers BuildVersionCache(Type objType)
        {
            var versionTypeAttribute = Attribute.GetCustomAttribute(objType, typeof(VersionTypeAttribute))
                                       as VersionTypeAttribute;
            if (versionTypeAttribute == null)
                throw new ArgumentException("No version type attribute specified for the type");

            var versionNo = versionTypeAttribute.Version;
            TypeVersionCache.TryAdd(objType, versionNo);
            return versionNo;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates cache instance of dictionary.
        /// </summary>
        static VersionCache()
        {
            TypeVersionCache = TypeVersionCache ?? new ConcurrentDictionary<Type, VersionNumbers>();
        }
        #endregion

        #region Private instance variables
        private static readonly ConcurrentDictionary<Type, VersionNumbers> TypeVersionCache;
        #endregion
    }
}
