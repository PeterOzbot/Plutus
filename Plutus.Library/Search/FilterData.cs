using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Search;

namespace Plutus.Library.Search {
    /// <summary>
    /// TODO
    /// </summary>
    public class FilterData : IFilterData {
        /// <summary>
        /// TODO
        /// </summary>
        public DateTime MinDate { get;  set; }
        /// <summary>
        /// TODO
        /// </summary>
        public DateTime MaxDate { get;  set; }



        /// <summary>
        /// TODO
        /// </summary>
        public FilterData() { }
    }
}
