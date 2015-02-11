using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Plutus.Portable.Data;
using Plutus.Web.Models;

namespace Plutus.Web.Controllers {
    /// <summary>
    /// TODO
    /// </summary>
    public class DisplayController : Controller {

        /// <summary>
        /// TODO
        /// </summary>
        [Dependency]
        public IEntryContext EntryContext { get; set; }




        /// <summary>
        /// TODO
        /// </summary>
        [Authorize]
        public ActionResult GeneralDisplay() {
            // load the data
            IEnumerable<IEntry> entries = EntryContext.Load(null);

            // create EntryListViewModel
            EntryListViewModel entryListViewModel = new EntryListViewModel(entries);

            // create EntriesGraphViewModel
            EntriesGraphViewModel entriesGraphViewModel = new EntriesGraphViewModel();

            // create generalDisplayViewModel
            GeneralDisplayViewModel generalDisplayViewModel = new GeneralDisplayViewModel(entryListViewModel, entriesGraphViewModel);

            // return view
            return View(generalDisplayViewModel);
        }
    }
}