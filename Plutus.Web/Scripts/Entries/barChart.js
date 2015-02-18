function BarChart() {
}

BarChart.prototype.Draw = function () {
    d3.selectAll("svg").remove();

    // Get the data
    response.forEach(function (d) {
        d.X = new Date(parseInt(d.X.substr(6)));
        d.Y = d.Y;
    });

    // Set the dimensions of the canvas / graph
    var margin = { top: 30, right: 20, bottom: 30, left: 50 },
        width = 700,//- margin.left - margin.right,
        height = 300;//- margin.top - margin.bottom;


    var minDate = response[0].X;
    var maxDate = response[response.length - 1].X;

    var minValue = d3.min(response, function (d) {
        return d.Y.Negative;
    });
    var maxValue = d3.max(response, function (d) {
        return d.Y.Positive;
    });

    minValue = minValue + minValue * 0.1;
    maxValue = maxValue + maxValue * 0.1;

    if (Math.abs(maxValue) > Math.abs(minValue)) {
        minValue = -maxValue;
    }
    else {
        maxValue = -minValue;
    }

    // color
    //var colorFunction = d3.scale.linear().domain(["#F7977A", "#78DD77"]).range([minValue, maxValue]);
    var color = d3.scale.linear()
        .domain([-1, 0, 1])
        .range(["red", "white", "green"]);

    // Set the ranges
    var y = d3.scale.linear().domain([minValue, maxValue]).range([height, 0]);
    var yPositive = d3.scale.linear().domain([minValue, maxValue]).range([height,0]);
    var yNegative = d3.scale.linear().domain([minValue, maxValue]).range([height, 0]);
    var x = d3.time.scale().domain([minDate, maxDate]).range([0, width]);

    // Define the axes
    var xAxis = d3.svg.axis().scale(x)
        .orient("bottom").ticks(20);

    var yAxis = d3.svg.axis().scale(y)
        .orient("left").ticks(10);

    // Adds the svg canvas
    var svg = d3.select(".entriesGraphs")
        .append("svg")
            .attr("width", width + 50)
            .attr("height", height + 50)
        .append("g")
            .attr("transform",
                  "translate(" + 50 + "," + 10 + ")");

    var barWidth = 20;

    var bar = svg.selectAll("g")
        .data(response)
      .enter().append("g")
        .attr("transform", function (d, i) { return "translate(" + i * barWidth + "," + 0 + ")"; });

    bar.append("rect")
        .attr("y", function (d) {
            return yPositive(d.Y.Positive);
        })
        .attr("height", function (d) {
            return (height / 2) - yPositive(d.Y.Positive);
        })
        .attr("fill", "#78DD77")
        .attr("width", barWidth - 1);


    bar.append("rect")
        .attr("y", function (d) {
            return yNegative(0);
        })
        .attr("height", function (d) {
            return yNegative(d.Y.Negative) - (height/2);
        })
        .attr("fill", "#F7977A")
        .attr("width", barWidth - 1);

    //bar.append("text")
    //    .attr("x", barWidth / 2)
    //    .attr("y", function (d) { return y(d.Y) + 3; })
    //    .attr("dy", ".75em")
    //    .text(function (d) { return d.Y; });


    // Add the X Axis
    svg.append("g")
        .attr("class", "x axis")
        .attr("transform", "translate(0," + height + ")")
        .call(xAxis);

    // Add the Y Axis
    svg.append("g")
        .attr("class", "y axis")
        .call(yAxis);
}