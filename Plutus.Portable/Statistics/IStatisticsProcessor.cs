using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plutus.Portable.Parsing;

namespace Plutus.Portable.Statistics {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IStatisticsProcessor : IEntryProcessor {
        /// <summary>
        /// TODO
        /// </summary>
        IStatisticsData Result { get; }
    }
}
