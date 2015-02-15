using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Data;
using Plutus.Portable.Search;

namespace Plutus.Web.Library.Search {
    /// <summary>
    /// TODO
    /// </summary>
    public class StandardFilter : IFilter {
        /// <summary>
        /// TODO
        /// </summary>
        public int? Top { get; private set; }
        /// <summary>
        /// TODO
        /// </summary>
        public Portable.Data.EntryType Type { get; private set; }
        /// <summary>
        /// TODO
        /// </summary>
        public int? LastID { get; private set; }


        /// <summary>
        /// TODO
        /// </summary>
        public StandardFilter(int? top, EntryType entryType, int? lastID = null) {
            Top = top;
            Type = entryType;
            LastID = lastID;
        }



    }
}
