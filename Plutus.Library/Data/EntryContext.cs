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
            : base("EntryContext") {
        }



        /// <summary>
        /// TODO
        /// </summary>
        public IEnumerable<IEntry> Load(IFilter filter) {
            return Entries;
        }
        /// <summary>
        /// TODO
        /// </summary>
        public IEntry Create(double value) {
            // create 
            Entry newEntry = new Entry() { Value = value, CreatedDateTime = DateTime.UtcNow };

            // save
            Entries.Add(newEntry);
            this.SaveChanges();

            return newEntry;
        }
    }
}
