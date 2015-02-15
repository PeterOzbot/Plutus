using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plutus.Portable.Statistics {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IStatisticsData {
        /// <summary>
        /// TODO
        /// </summary>
        double TotalPositive { get; }
        /// <summary>
        /// TODO
        /// </summary>
        double TotalNegative { get; }
        /// <summary>
        /// TODO
        /// </summary>
        double Sum { get; }
    }
}
