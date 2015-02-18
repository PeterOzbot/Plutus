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

        private DateTime? _currentX = null;
        private PointValue _currentY = new PointValue() { Positive = 0, Negative = 0 };

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

            // if current x is null set from current entry
            if (!_currentX.HasValue) {
                _currentX = entry.CreatedDateTime;
            }

            // calculate time difference
            TimeSpan difference = entry.CreatedDateTime - _currentX.Value;

            // reset current X and create point from entries in last day
            if (difference.Duration() >= TimeSpan.FromDays(1).Duration()) {
                // create point from data
                _result.Add(new Point(_currentX.Value, _currentY));

                // set current value for next calculations
                SetCurrentY(entry);
                _currentX = entry.CreatedDateTime;
            }
            // add to current Y value from entry
            else {
                AddCurrentY(entry);
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void Finish() {

            // if x is not null then one more point must be created
            if (_currentX.HasValue) {
                _result.Add(new Point(_currentX.Value, _currentY));
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void SetCurrentY(Portable.Data.IEntry entry) {
            _currentY = new PointValue();

            // set current value for next calculations
            if (entry.Type == Portable.Data.EntryType.Positive) {
                _currentY.Positive = entry.Value;
            }
            if (entry.Type == Portable.Data.EntryType.Negative) {
                _currentY.Negative = entry.Value;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void AddCurrentY(Portable.Data.IEntry entry) {
            // set current value for next calculations
            if (entry.Type == Portable.Data.EntryType.Positive) {
                _currentY.Positive += entry.Value;
            }
            if (entry.Type == Portable.Data.EntryType.Negative) {
                _currentY.Negative += entry.Value;
            }
        }
    }
}
