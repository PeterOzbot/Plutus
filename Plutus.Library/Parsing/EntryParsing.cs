using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plutus.Portable.Data;
using Plutus.Portable.Parsing;

namespace Plutus.Library.Parsing {
    /// <summary>
    /// TODO
    /// </summary>
    public class EntryParsing : IEntryParsing {
        /// <summary>
        /// TODO
        /// </summary>
        public List<IEntryProcessor> RegisteredProcessors { get; set; }




        /// <summary>
        /// TODO
        /// </summary>
        public EntryParsing() {
            RegisteredProcessors = new List<IEntryProcessor>();
        }





        /// <summary>
        /// TODO
        /// </summary>
        public void Parse(IEnumerable<Portable.Data.IEntry> entries) {

            // go through all the entries and process them with registered processors
            foreach (IEntry entry in entries) {
                Parallel.ForEach(RegisteredProcessors, (processor) => { processor.Process(entry); });
            }

            // notify finish
            Parallel.ForEach(RegisteredProcessors, (processor) => { processor.Finish(); });
        }
        /// <summary>
        /// TODO
        /// </summary>
        public void Register(IEntryProcessor entryProcessor) {
            RegisteredProcessors.Add(entryProcessor);
        }
    }
}
