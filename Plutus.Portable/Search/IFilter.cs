﻿using System;
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
        DateTime MinDate { get; }
        /// <summary>
        /// TODO
        /// </summary>
        DateTime MaxDate { get; }
    }
}
