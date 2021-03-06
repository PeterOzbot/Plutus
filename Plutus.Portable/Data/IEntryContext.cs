﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Framework;
using Plutus.Portable.Search;
using Plutus.Portable.Statistics;

namespace Plutus.Portable.Data {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IEntryContext {
        /// <summary>
        /// TODO
        /// </summary>
        IEnumerable<IEntry> LoadEntries(IFilter filter);
        /// <summary>
        /// TODO
        /// </summary>
        IFilterData GetFilterData();
        /// <summary>
        /// TODO
        /// </summary>
        IEntry Create(IEntry entry);
    }
}
