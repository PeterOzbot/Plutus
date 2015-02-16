using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Data;

namespace Plutus.Portable.Parsing {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IEntryParsing {
        /// <summary>
        /// TODO
        /// </summary>
        void Parse(IEnumerable<IEntry> entries);
        /// <summary>
        /// TODO
        /// </summary>
        void Register(IEntryProcessor entryProcessor);
    }
}
