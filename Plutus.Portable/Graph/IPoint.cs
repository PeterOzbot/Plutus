using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plutus.Portable.Graph {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IPoint<XType, YType> : IPoint {
        /// <summary>
        /// TODO
        /// </summary>
        XType X { get; }
        /// <summary>
        /// TODO
        /// </summary>
        YType Y { get; }
    }

    /// <summary>
    /// TODO
    /// </summary>
    public interface IPoint {
    }

    /// <summary>
    /// TODO
    /// </summary>
    public static class IPointExtensions {
        /// <summary>
        /// TODO
        /// </summary>
        public static IPoint<XType, YType> Get<XType, YType>(this IPoint point) {
            return point as IPoint<XType, YType>;
        }
    }
}
