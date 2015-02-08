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
        public ActionResult EntryList() {
            // load the data
            IEnumerable<IEntry> entries = EntryContext.Load(null);

            // create view model
            EntryListViewModel viewModel = new EntryListViewModel(entries);

            // return view
            return View(viewModel);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public JsonResult CreateEntry(double value) {
            try {
                IEntry createdEntry = EntryContext.Create(value);
                return Json(new { Success = true, Entry = createdEntry });
            }
            catch {
                // TODO: error logging
                return Json(new { Success = false });
            }


        }
    }
}