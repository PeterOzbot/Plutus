using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plutus.Portable.Data;

namespace Plutus.Portable.Parsing {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IEntryProcessor {
        /// <summary>
        /// TODO
        /// </summary>
        void Process(IEntry entry);
        /// <summary>
        /// TODO
        /// </summary>
        void Finish();
    }
}
