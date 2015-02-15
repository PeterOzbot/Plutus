using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Library.Statistics;
using Plutus.Portable.Data;
using Plutus.Portable.Framework;
using Plutus.Portable.Search;
using Plutus.Portable.Statistics;

namespace Plutus.Library.Data {
    /// <summary>
    /// TODO
    /// </summary>
    public class EntryContext : DbContext, IEntryContext {
        /// <summary>
        /// TODO
        /// </summary>
        public DbSet<Entry> Entries { get; set; }



        /// <summary>
        /// TODO
        /// </summary>
        public EntryContext()
            : base() {
        }



        /// <summary>
        /// TODO
        /// </summary>
        public IEnumerable<IEntry> LoadEntries(IFilter filter) {
            IEnumerable<IEntry> result;

            // create default filter if <filter> is null
            filter = filter ?? new DefaultFilter();

            // filter !
            if (filter.Top.HasValue) {
                result = (from entry in Entries
                          where
                              // filter for type
                          ((filter.Type == EntryType.All) || (filter.Type == EntryType.Negative && entry.Value < 0) || (filter.Type == EntryType.Positive && entry.Value > 0))
                              // filter by last id
                          && ((filter.LastID.HasValue && entry.ID > filter.LastID) || !filter.LastID.HasValue)

                          // order
                          orderby entry.CreatedDateTime descending
                          select entry)
                    // take top
                          .Take(filter.Top.Value);
            }
            else {
                result = from entry in Entries
                         where
                             // filter for type
                         ((filter.Type == EntryType.All) || (filter.Type == EntryType.Negative && entry.Value < 0) || (filter.Type == EntryType.Positive && entry.Value > 0))
                             // filter by last id
                         && ((filter.LastID.HasValue && entry.ID > filter.LastID) || !filter.LastID.HasValue)

                         // order
                         orderby entry.CreatedDateTime descending
                         select entry;
            }


            // return data
            return result;
        }


        ///// <summary>
        ///// TODO
        ///// </summary>
        //public IStatisticsData LoadEntriesStatistics(IFilter filter) {
        //    IEnumerable<PartialStatisticData> partialStatisticData;

        //    // get statistics grouped by positive/negative value
        //    partialStatisticData = from entry in Entries
        //                           group entry by entry.Value > 0
        //                               into groupedEntries
        //                               select new PartialStatisticData() { Value = groupedEntries.Sum(entry => entry.Value), GroupKey = groupedEntries.Key };

        //    // create statistic data
        //    IStatisticsData statisticData;

        //    // check for data
        //    if (partialStatisticData.Any()) {

        //        // if there are two results it means that both positive and negative exists nad both values should be used
        //        if (partialStatisticData.Count() == 2) {

        //            if (partialStatisticData.First().Value > 0) {
        //                statisticData = new DefaultStatistics(partialStatisticData.First().Value, partialStatisticData.Last().Value);
        //            }
        //            else {
        //                statisticData = new DefaultStatistics(partialStatisticData.Last().Value, partialStatisticData.First().Value);
        //            }
        //        }
        //        else {

        //            // only one positive or only negative exists
        //            // check which and create statistic
        //            if (partialStatisticData.First().GroupKey) {
        //                statisticData = new DefaultStatistics(partialStatisticData.First().Value, 0);
        //            }
        //            else {
        //                statisticData = new DefaultStatistics(0, partialStatisticData.First().Value);
        //            }
        //        }
        //    }
        //    else {
        //        // if no data just create empty
        //        statisticData = new DefaultStatistics(0, 0);
        //    }

        //    // return result
        //    return statisticData;
        //}

        /// <summary>
        /// TODO
        /// </summary>
        public IEntry Create(IEntry entry) {
            // create 
            Entry newEntry = new Entry(entry) { CreatedDateTime = DateTime.UtcNow };

            // save
            Entries.Add(newEntry);
            this.SaveChanges();

            return newEntry;
        }
    }

    /// <summary>
    /// TODO
    /// </summary>
    public class DefaultFilter : IFilter {
        /// <summary>
        /// TODO
        /// </summary>
        public int? Top { get { return null; ; } }

        /// <summary>
        /// TODO
        /// </summary>
        public EntryType Type { get { return EntryType.All; } }

        /// <summary>
        /// TODO
        /// </summary>
        public int? LastID { get { return null; } }
    }
}
