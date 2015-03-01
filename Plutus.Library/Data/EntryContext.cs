using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Library.Search;
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
            //if (filter.Top.HasValue) {
            result = (from entry in Entries
                      where
                          //    // filter for type
                          //((filter.Type == EntryType.All) || (filter.Type == EntryType.Negative && entry.Value < 0) || (filter.Type == EntryType.Positive && entry.Value > 0))
                          //    // filter by last id
                          //&& ((filter.LastID.HasValue && entry.ID > filter.LastID) || !filter.LastID.HasValue)

                      // filter by date range
                      entry.CreatedDateTime >= filter.MinDate && entry.CreatedDateTime <= filter.MaxDate

                      // order
                      orderby entry.CreatedDateTime descending
                      select entry);
                    // take top
                      //    .Take(filter.Top.Value);
            //}
            //else {
            //    result = from entry in Entries
            //             where
            //                 // filter for type
            //             ((filter.Type == EntryType.All) || (filter.Type == EntryType.Negative && entry.Value < 0) || (filter.Type == EntryType.Positive && entry.Value > 0))
            //                 // filter by last id
            //             && ((filter.LastID.HasValue && entry.ID > filter.LastID) || !filter.LastID.HasValue)

            //             // order
            //             orderby entry.CreatedDateTime descending
            //             select entry;
            //}


            // return data
            return result;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public IFilterData GetFilterData() {
            // get data
            IEnumerable<FilterData> filterData = from entry in Entries
                                                 group entry by 0 into entryGroup
                                                 select new FilterData() {
                                                     MinDate = entryGroup.Min(entry => entry.CreatedDateTime),
                                                     MaxDate = entryGroup.Max(entry => entry.CreatedDateTime)
                                                 };

            // return data
            return filterData.Count() > 0 ? filterData.First() : new FilterData() { MinDate = DateTime.UtcNow.AddDays(-14), MaxDate = DateTime.UtcNow };
        }

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
        public DateTime MinDate { get { return DateTime.UtcNow.AddDays(14); } }
        /// <summary>
        /// TODO
        /// </summary>
        public DateTime MaxDate { get { return DateTime.UtcNow; } }
    }
}
