using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Graph;

namespace Plutus.Library.Graph {
    /// <summary>
    /// TODO
    /// </summary>
    public class GraphProcessor : IGraphProcessor {
        private List<IPoint> _result;

        /// <summary>
        /// TODO
        /// </summary>
        public IEnumerable<IPoint> Result { get { return _result; } }


        public GraphProcessor() {
            _result = new List<IPoint>();
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void Process(Portable.Data.IEntry entry) {
            // TODO:FIX - for now just assume that entries come ordered

            _result.Add(new Point(entry.CreatedDateTime, entry.Value));
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void Finish() {
            // do nothing
        }
    }
}
