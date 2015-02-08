using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Framework;
using Plutus.Portable.Search;

namespace Plutus.Portable.Data {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IEntryContext {
        /// <summary>
        /// TODO
        /// </summary>
        IEnumerable<IEntry> Load(IFilter filter);
        /// <summary>
        /// TODO
        /// </summary>
        IEntry Create(double value);
    }
}
