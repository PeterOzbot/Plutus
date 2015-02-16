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
    public class Point : IPoint {
        /// <summary>
        /// TODO
        /// </summary>
        public DateTime X { get; private set; }
        /// <summary>
        /// TODO
        /// </summary>
        public double Y { get; private set; }



        /// <summary>
        /// TODO
        /// </summary>
        public Point(DateTime x, double y) {
            X = x;
            Y = y;
        }
    }
}
