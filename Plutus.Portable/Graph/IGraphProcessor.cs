using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plutus.Portable.Parsing;

namespace Plutus.Portable.Graph {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IGraphProcessor : IEntryProcessor {
        /// <summary>
        /// TODO
        /// </summary>
        IEnumerable<IPoint> Result { get; }
    }
}
