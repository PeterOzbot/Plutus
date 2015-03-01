function Filter(filterData, defaultValue) {
    this.FilterData = filterData;
    this.DefaultValue = defaultValue;
    this.Months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    this.Timer = null;
}

Filter.prototype.Initialize = function () {
    var months = this.Months;
    var filterData = this.FilterData;
    var defaultValue = this.DefaultValue;

    $("#slider").dateRangeSlider({

        bounds: {
            min: new Date(parseInt(filterData.MinDate.substr(6))),
            max: new Date(parseInt(filterData.MaxDate.substr(6)))
        }
        , defaultValues: {
            min: new Date(parseInt(defaultValue.MinDate.substr(6))),
            max: new Date(parseInt(defaultValue.MaxDate.substr(6)))
        }
    });

    $("#slider").on("valuesChanging", function (e, data) {
        clearTimeout(this.Timer);
        this.Timer = setTimeout(function () {
            RefreshGeneralDisplay({ MinDate: data.values.min, MaxDate: data.values.max });
        }, 1500);
    });
}