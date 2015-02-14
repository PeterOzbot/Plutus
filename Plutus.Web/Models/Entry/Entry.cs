using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Plutus.Portable.Data;

namespace Plutus.Web.Models.Entry {
    /// <summary>
    /// TODO
    /// </summary>
    public class Entry : IEntry {

        /// <summary>
        /// TODO
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [Required]
        public double Value { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public EntryType Type { get { return Value > 0 ? EntryType.Positive : EntryType.Negative; } }




        /// <summary>
        /// TODO
        /// </summary>
        public Entry() {

        }
    }
}