using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plutus.Portable.Data;

namespace Plutus.Web.Models {
    /// <summary>
    /// TODO
    /// </summary>
    public class EntryListViewModel {
        /// <summary>
        /// TODO
        /// </summary>
        public IEnumerable<IEntry> Entries { get; set; }



        /// <summary>
        /// TODO
        /// </summary>
        public EntryListViewModel(IEnumerable<IEntry> entries) {
            Entries = entries;
        }
    }
}