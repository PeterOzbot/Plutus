using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Plutus.Portable.Data;
using Plutus.Web.Models.Entry;

namespace Plutus.Web.Controllers {
    public class EntryController : Controller {
        /// <summary>
        /// TODO
        /// </summary>
        [Dependency]
        public IEntryContext EntryContext { get; set; }





        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CreateNew() {
            return View("EntryEdit", new Entry());
        }

        /// <summary>
        /// TODO
        /// </summary>
        [Authorize]
        [HttpPost]
        [ValidateInput(true)]
        public JsonResult CreateEntry(Entry entry) {
            try {
                // create
                IEntry createdEntry = EntryContext.Create(entry);

                // return
                return Json(new { Success = true, Entry = PartialViewToString("~/Views/Display/EntryListRow.cshtml", createdEntry) }, JsonRequestBehavior.AllowGet);
            }
            catch {
                // TODO: error logging
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// Converts View to html string
        /// </summary>
        /// <param name="viewName">View name</param>
        /// <param name="model">Model</param>
        /// <returns>String with view name</returns>
        public string PartialViewToString(string viewName, object model) {
            if (string.IsNullOrEmpty(viewName)) {
                viewName = ControllerContext.RouteData.GetRequiredString("action");
            }

            ViewData.Model = model;

            using (StringWriter stringWriter = new StringWriter()) {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, stringWriter);
                viewResult.View.Render(viewContext, stringWriter);
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}