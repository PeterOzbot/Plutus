using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plutus.Portable.Data;
using Plutus.Portable.Graph;

namespace Plutus.Web.Models {
    /// <summary>
    /// TODO
    /// </summary>
    public class EntriesGraphViewModel {
        /// <summary>
        /// TODO
        /// </summary>
        public IEnumerable<IPoint> Points { get; set; }



        /// <summary>
        /// TODO
        /// </summary>
        public EntriesGraphViewModel(IEnumerable<IPoint> points) {
            Points = points;
        }
    }
}