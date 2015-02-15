using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plutus.Portable.Data {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IEntry {
        /// <summary>
        /// TODO
        /// </summary>
        string Description { get; }
        /// <summary>
        /// TODO
        /// </summary>
        double Value { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        DateTime CreatedDateTime { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        EntryType Type { get; }
    }
}
