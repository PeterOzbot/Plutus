using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Plutus.Portable.Data;
using Plutus.Portable.Statistics;
using Plutus.Web.Library.Search;
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
        [Dependency]
        public IStatisticsParser StatisticsParser { get; set; }




        /// <summary>
        /// TODO
        /// </summary>
        [Authorize]
        public ActionResult GeneralDisplay() {
            // load the data
            List<IEntry> entries = EntryContext.LoadEntries(new StandardFilter(null, EntryType.All)).ToList();

            // create EntryListViewModel
            EntryListViewModel entryListViewModel = new EntryListViewModel(entries);

            //



            // create EntriesGraphViewModel
            EntriesGraphViewModel entriesGraphViewModel = new EntriesGraphViewModel(entries);

            // load statistics
            IStatisticsData statisticsData = StatisticsParser.Parse(entries);

            // create EntriesStatisticsViewModel
            EntriesStatisticsViewModel entriesStatisticsViewModel = new EntriesStatisticsViewModel(statisticsData);

            // create generalDisplayViewModel
            GeneralDisplayViewModel generalDisplayViewModel = new GeneralDisplayViewModel(entryListViewModel, entriesGraphViewModel, entriesStatisticsViewModel);

            // return view
            return View(generalDisplayViewModel);
        }
    }
}