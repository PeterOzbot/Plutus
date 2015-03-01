using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plutus.Portable.Search {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IFilterData {
        /// <summary>
        /// TODO
        /// </summary>
        DateTime MinDate { get; }
        /// <summary>
        /// TODO
        /// </summary>
        DateTime MaxDate { get; }
    }
}
