using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plutus.Portable.Data;

namespace Plutus.Web.Models {
    /// <summary>
    /// TODO
    /// </summary>
    public class EntriesStatisticsViewModel {
        /// <summary>
        /// TODO
        /// </summary>
        public IEnumerable<IEntry> Entries { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        public double TotalSpending { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        public double TotalEarnings { get; set; }




        /// <summary>
        /// TODO
        /// </summary>
        public EntriesStatisticsViewModel(IEnumerable<IEntry> entries) {
            Entries = entries;
            ProcessEntries();
        }




        /// <summary>
        /// TODO
        /// </summary>
        private void ProcessEntries() {
            TotalEarnings = 0;
            TotalSpending = 0;

            foreach (IEntry entry in Entries) {
                if (entry.Type == EntryType.Negative) {
                    ProcessSpending(entry);
                }
                else if (entry.Type == EntryType.Positive) {
                    ProcessEarnings(entry);
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void ProcessEarnings(IEntry entry) {
            TotalEarnings += entry.Value;
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void ProcessSpending(IEntry entry) {
            TotalSpending += Math.Abs(entry.Value);
        }
    }
}