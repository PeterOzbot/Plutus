using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Graph;

namespace Plutus.Library.Graph {
    /// <summary>
    /// TODO
    /// </summary>
    public class Point : IPoint<DateTime, PointValue> {
        /// <summary>
        /// TODO
        /// </summary>
        public DateTime X { get; private set; }
        /// <summary>
        /// TODO
        /// </summary>
        public PointValue Y { get; private set; }



        /// <summary>
        /// TODO
        /// </summary>
        public Point(DateTime x, PointValue y) {
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// TODO
    /// </summary>
    public class PointValue {
        /// <summary>
        /// TODO
        /// </summary>
        public double Positive { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        public double Negative { get; set; }



        /// <summary>
        /// TODO
        /// </summary>
        public PointValue() { }
    }
}
