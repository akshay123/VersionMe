using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versioning.Engine
{
    public class ObjectConverter
    {
     
        /// <summary>
        /// Convert from Any version to Any version
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public K Convert<T, K>(T source) where K : class
        {

            var sourceVersion = VersionCache.GetVersion(source.GetType());
            var destinationVersion = VersionCache.GetVersion(typeof(K));

            if (destinationVersion == sourceVersion) return source as K;

            if (destinationVersion > sourceVersion)
                return UpgradeVersionTo(source, destinationVersion) as K;

            if (destinationVersion < sourceVersion)
                return DowngradeVersionTo(source, destinationVersion) as K;

            return null;

        }

        /// <summary>
        /// Convert, a dynamic to any type you care about. 
        /// Note: this is mostly used when you have serialized data and do not know its version.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public T ConvertFromDynamic<T>(dynamic source) where T : class
        {
            var sourceVersion = VersionCache.GetVersion(source.GetType());
            var destinationVersion = VersionCache.GetVersion(typeof(T));

            if (destinationVersion == sourceVersion) return source as T;

            if (destinationVersion > sourceVersion)
                return UpgradeVersionTo(source, destinationVersion) as T;

            if (destinationVersion < sourceVersion)
                return DowngradeVersionTo(source, destinationVersion) as T;

            return null;
        }

         /// <summary>
        /// Convert upgraded version to latest class template.
        /// FASTEST
        /// </summary>
        /// <typeparam name="T">Latest versioned class</typeparam>
        /// <param name="source">Any source object with Version attribute</param>
        /// <returns>Object of type T</returns>       
        public T UpgradeToLatestVersion<T>(dynamic source) where T:class
        {
            var targetObj = source;
            while (true)
            {
                var tempObj = targetObj.Upgrade();
                if (tempObj == null) break;
                targetObj = tempObj;
            }
            return targetObj as T;
        }

        /// <summary>
        /// Upgrades version to the specific version.
        /// </summary>
        /// <remarks>
        /// It internally calls the Upgrade of the immediate higher version, and so on.
        /// </remarks>
        /// <param name="source"></param>
        /// <param name="versionNumber"></param>
        /// <returns></returns>
        private dynamic UpgradeVersionTo(dynamic source, VersionNumbers versionNumber)
        {
            var targetObj = source;
            var targetVersion = VersionCache.GetVersion(targetObj.GetType());
            while (targetVersion != versionNumber)
            {
                var tempObj = targetObj.Upgrade();
                if (tempObj == null) break;

                targetVersion = VersionCache.GetVersion(tempObj.GetType());
              
                targetObj = tempObj;
            }

            return targetObj;
        }

        /// <summary>
        /// Upgrades version to the particular version
        /// </summary>
        /// <remarks>It internally calls the Downgrade of the immediate lower version, and so on</remarks>
        /// <param name="source"></param>
        /// <param name="version"></param>
        /// <returns>downgraded version</returns>
        private dynamic DowngradeVersionTo(dynamic source, VersionNumbers version)
        {
            var targetObj = source;
            var targetVersion = VersionCache.GetVersion(targetObj.GetType());
            while (targetVersion > version)
            {
                var tempObj = targetObj.Downgrade();
                if (tempObj == null) break;

                targetVersion = VersionCache.GetVersion(tempObj.GetType());
               
                targetObj = tempObj;
            }

            return targetObj;
        }
      
    }
}
