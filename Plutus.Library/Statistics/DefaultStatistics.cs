using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Statistics;

namespace Plutus.Library.Statistics {
    /// <summary>
    /// TODO
    /// </summary>
    public class DefaultStatistics : IStatisticsData {
        /// <summary>
        /// TODO
        /// </summary>
        public double TotalPositive { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        public double TotalNegative { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        public double Sum { get; set; }



        /// <summary>
        /// TODO
        /// </summary>
        public DefaultStatistics(double totalPositive, double totalNegative, double sum) {
            TotalPositive = totalPositive;
            TotalNegative = totalNegative;
            Sum = sum;
        }
    }
}
