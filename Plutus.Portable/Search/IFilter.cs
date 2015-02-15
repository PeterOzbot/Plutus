using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Data;

namespace Plutus.Portable.Search {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IFilter {
        /// <summary>
        /// TODO
        /// </summary>
        int? Top { get; }
        /// <summary>
        /// TODO
        /// </summary>
        EntryType Type { get; }
        /// <summary>
        /// TODO
        /// </summary>
        int? LastID { get; }
    }
}
