using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plutus.Portable.Data;
using Plutus.Portable.Statistics;

namespace Plutus.Web.Models {
    /// <summary>
    /// TODO
    /// </summary>
    public class EntriesStatisticsViewModel {
        /// <summary>
        /// TODO
        /// </summary>
        public IStatisticsData StatisticsData { get; set; }



        /// <summary>
        /// TODO
        /// </summary>
        public EntriesStatisticsViewModel(IStatisticsData statisticsData) {
            StatisticsData = statisticsData ?? new EmptyStatisticsData();
        }
    }


    /// <summary>
    /// TODO
    /// </summary>
    public class EmptyStatisticsData : IStatisticsData {
        /// <summary>
        /// TODO
        /// </summary>
        public double TotalPositive { get { return 0; } }
        /// <summary>
        /// TODO
        /// </summary>
        public double TotalNegative { get { return 0; } }
        /// <summary>
        /// TODO
        /// </summary>
        public double Sum { get { return 0; } }



        /// <summary>
        /// TODO
        /// </summary>
        public EmptyStatisticsData() { }
    }
}