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
    public class StatisticsParser : IStatisticsParser {


        /// <summary>
        /// TODO
        /// </summary>
        public IStatisticsData Parse(IEnumerable<IEntry> entries) {
            DefaultStatistics statisticsData = null;

            double positive = 0;
            double negative = 0;

            foreach (IEntry entry in entries) {

                if (entry.Type == EntryType.Positive) {
                    positive += entry.Value;
                }
                else {
                    negative += entry.Value;
                }
            }


            statisticsData = new DefaultStatistics(positive, negative, positive + negative);


            //var result = from entry in entries
            //             group entry by entry.Type
            //                 into groupedEntries
            //                 select new { Value = groupedEntries.Sum(entry => entry.Value), GroupKey = groupedEntries.Key };


            //var result2 = from entry in entries
            //              select entry.Type == EntryType.Positive ? positive += entry.Value : negative += entry.Value;

            //entries.Select(i=> new DefaultStatistics(););


            //IEnumerable<IGrouping<EntryType, IEntry>> group = entries.GroupBy<IEntry, EntryType>((entry) => { return entry.Type; });

            //var positiveResult = group.ToList();

            //positive = 1;





            // return data
            return statisticsData;
        }
    }
}
