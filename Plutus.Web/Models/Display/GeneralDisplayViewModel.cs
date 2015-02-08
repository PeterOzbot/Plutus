using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plutus.Web.Models {
    /// <summary>
    /// TODO
    /// </summary>
    public class GeneralDisplayViewModel {
        /// <summary>
        /// TODO
        /// </summary>
        public EntryListViewModel EntryListViewModel { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        public EntriesGraphViewModel EntriesGraphViewModel { get; set; }



        /// <summary>
        /// TODO
        /// </summary>
        public GeneralDisplayViewModel(EntryListViewModel entryListViewModel, EntriesGraphViewModel entriesGraphViewModel) {
            EntriesGraphViewModel = entriesGraphViewModel;
            EntryListViewModel = entryListViewModel;
        }
    }
}