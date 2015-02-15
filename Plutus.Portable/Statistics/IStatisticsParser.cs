using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Data;

namespace Plutus.Portable.Statistics {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IStatisticsParser {
        /// <summary>
        /// TODO
        /// </summary>
        IStatisticsData Parse(IEnumerable<IEntry> entries);
    }
}
