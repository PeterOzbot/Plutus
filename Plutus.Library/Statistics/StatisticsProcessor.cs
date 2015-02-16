using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Data;
using Plutus.Portable.Statistics;

namespace Plutus.Library.Statistics {
    /// <summary>
    /// TODO
    /// </summary>
    public class StatisticsProcessor : IStatisticsProcessor {
        private double _totalPositive;
        private double _totalNegative;


        /// <summary>
        /// TODO
        /// </summary>
        public IStatisticsData Result { get; private set; }





        /// <summary>
        /// TODO
        /// </summary>
        public StatisticsProcessor() {
            _totalNegative = 0;
            _totalPositive = 0;
        }





        /// <summary>
        /// TODO
        /// </summary>
        public void Process(IEntry entry) {
            if (entry.Type == EntryType.Negative) {
                _totalNegative += entry.Value;
            }
            if (entry.Type == EntryType.Positive) {
                _totalPositive += entry.Value;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void Finish() {
            // calculate sum
            double sum = _totalPositive + _totalNegative;

            // set result
            Result = new DefaultStatistics(_totalPositive, _totalNegative, sum);
        }

        ///// <summary>
        ///// TODO
        ///// </summary>
        //public IStatisticsData Parse(IEnumerable<IEntry> entries) {
        //    DefaultStatistics statisticsData = null;

        //    double positive = 0;
        //    double negative = 0;

        //    foreach (IEntry entry in entries) {

        //        if (entry.Type == EntryType.Positive) {
        //            positive += entry.Value;
        //        }
        //        else {
        //            negative += entry.Value;
        //        }
        //    }


        //    statisticsData = new DefaultStatistics(positive, negative, positive + negative);


        //    //var result = from entry in entries
        //    //             group entry by entry.Type
        //    //                 into groupedEntries
        //    //                 select new { Value = groupedEntries.Sum(entry => entry.Value), GroupKey = groupedEntries.Key };


        //    //var result2 = from entry in entries
        //    //              select entry.Type == EntryType.Positive ? positive += entry.Value : negative += entry.Value;

        //    //entries.Select(i=> new DefaultStatistics(););


        //    //IEnumerable<IGrouping<EntryType, IEntry>> group = entries.GroupBy<IEntry, EntryType>((entry) => { return entry.Type; });

        //    //var positiveResult = group.ToList();

        //    //positive = 1;





        //    // return data
        //    return statisticsData;
        //}
    }
}
