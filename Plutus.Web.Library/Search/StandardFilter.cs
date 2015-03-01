using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Data;
using Plutus.Portable.Search;

namespace Plutus.Web.Library.Search {
    /// <summary>
    /// TODO
    /// </summary>
    public class StandardFilter : IFilter {
        /// <summary>
        /// TODO
        /// </summary>
        public DateTime MinDate { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        public DateTime MaxDate { get; set; }


        /// <summary>
        /// TODO
        /// </summary>
        public StandardFilter(DateTime minDate, DateTime maxDate) {
            MaxDate = maxDate;
            MinDate = minDate;
        }
        /// <summary>
        /// TODO
        /// </summary>
        public StandardFilter() { }
    }
}
