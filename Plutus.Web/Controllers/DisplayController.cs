﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Plutus.Portable.Data;
using Plutus.Portable.Graph;
using Plutus.Portable.Parsing;
using Plutus.Portable.Search;
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
        public IEntryParsing EntryParsing { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        [Dependency]
        public IGraphProcessor GraphProcessor { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        [Dependency]
        public IStatisticsProcessor StatisticsProcessor { get; set; }




        /// <summary>
        /// TODO
        /// </summary>
        [Authorize]
        public ActionResult GeneralDisplay(StandardFilter standardFilter) {
            GeneralDisplayViewModel generalDisplayViewModel = CreateGeneralDisplayViewModel(standardFilter);

            // return view
            return View(generalDisplayViewModel);
        }
        /// <summary>
        /// TODO
        /// </summary>
        [Authorize]
        public ActionResult GeneralDisplayContent(StandardFilter standardFilter) {
            Task.Delay(5000).Wait();
            GeneralDisplayViewModel generalDisplayViewModel = CreateGeneralDisplayViewModel(standardFilter);

            // return view
            return View(generalDisplayViewModel);
        }

        private GeneralDisplayViewModel CreateGeneralDisplayViewModel(StandardFilter standardFilter) {
            // load the data
            IEnumerable<IEntry> entries = EntryContext.LoadEntries(standardFilter);

            // register parsers
            EntryParsing.Register(GraphProcessor);
            EntryParsing.Register(StatisticsProcessor);

            // parse data
            EntryParsing.Parse(entries);

            // create EntryListViewModel
            EntryListViewModel entryListViewModel = new EntryListViewModel(entries);


            // create EntriesGraphViewModel
            EntriesGraphViewModel entriesGraphViewModel = new EntriesGraphViewModel(GraphProcessor.Result);

            // create EntriesStatisticsViewModel
            EntriesStatisticsViewModel entriesStatisticsViewModel = new EntriesStatisticsViewModel(StatisticsProcessor.Result);

            //TODO: move filter to another action and create sepparate call for it or something
            // get filter data
            IFilterData filterData = EntryContext.GetFilterData();

            // create FilterViewModel
            FilterViewModel filterViewModel = new FilterViewModel(filterData);


            // create generalDisplayViewModel
            GeneralDisplayViewModel generalDisplayViewModel = new GeneralDisplayViewModel(entryListViewModel, entriesGraphViewModel, entriesStatisticsViewModel, filterViewModel);
            // return ...
            return generalDisplayViewModel;
        }
    }
}