﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plutus.Portable.Data;

namespace Plutus.Library.Data {
    /// <summary>
    /// TODO
    /// </summary>
    public class Entry : IEntry {
        /// <summary>
        /// TODO
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        public string Description { get; set; }
    }
}