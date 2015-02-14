using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Data;
using Plutus.Portable.Framework;
using Plutus.Portable.Search;

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
        public IEnumerable<IEntry> Load(IFilter filter) {
            IEnumerable<IEntry> result;

            // create default filter if <filter> is null
            filter = filter ?? new DefaultFilter();

            // filter !
            result = (from entry in Entries
                      where
                          // filter for type
                      ((filter.Type == EntryType.All) || (filter.Type == EntryType.Negative && entry.Value < 0) || (filter.Type == EntryType.Positive && entry.Value > 0))
                          // filter by last id
                      && ((filter.LastID.HasValue && entry.ID > filter.LastID) || !filter.LastID.HasValue)

                      // order
                      orderby entry.ID descending

                      select entry)
                // take top
                      .Take(filter.Top);

            // return data
            return result;
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
        public int Top { get { return 100; } }

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
