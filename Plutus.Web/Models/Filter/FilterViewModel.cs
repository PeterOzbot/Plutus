using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plutus.Portable.Search;

namespace Plutus.Web.Models {
    /// <summary>
    /// TODO
    /// </summary>
    public class FilterViewModel {
        /// <summary>
        /// TODO
        /// </summary>
        public IFilterData FilterData { get; set; }
        /// <summary>
        /// TODO
        /// </summary>
        public FilterDefaultValue DefaultValue { get; set; }



        /// <summary>
        /// TODO
        /// </summary>
        public FilterViewModel(IFilterData filterData) {
            FilterData = filterData;
            DefaultValue = new FilterDefaultValue(filterData);
        }
    }


    /// <summary>
    /// TODO
    /// </summary>
    public class FilterDefaultValue {
        /// <summary>
        /// TODO
        /// </summary>
        public DateTime MinDate { get; private set; }
        /// <summary>
        /// TODO
        /// </summary>
        public DateTime MaxDate { get; private set; }



        /// <summary>
        /// TODO
        /// </summary>
        public FilterDefaultValue(IFilterData filterData) {
            MaxDate = filterData.MaxDate;

            DateTime minDate = filterData.MaxDate.AddDays(-((filterData.MaxDate - filterData.MinDate).Days * 0.1));
            MinDate = minDate > filterData.MinDate ? minDate : filterData.MinDate;
        }
    }
}