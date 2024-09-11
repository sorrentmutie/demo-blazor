export function showChart() {
    var data = {
        // A labels array that can contain any sort of values
        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
        // Our series array that contains series objects or in this case series data arrays
        series: [
            [5, 2, 4, 2, 0]
        ]
    };

    // Create a new line chart object where as first parameter we pass in a selector
    // that is resolving to our chart container element. The Second parameter
    // is the actual data object.
    new Chartist.Line('.ct-chart', data);
}

export function showChart2(id) {    
    var data = {
        // A labels array that can contain any sort of values
        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
        // Our series array that contains series objects or in this case series data arrays
        series: [
            [5, 2, 4, 2, 0]
        ]
    };

    // Create a new line chart object where as first parameter we pass in a selector
    // that is resolving to our chart container element. The Second parameter
    // is the actual data object.
    new Chartist.Line("#"+id, data);
}

export function showChart3(id, type) {
    var data = {
        // A labels array that can contain any sort of values
        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
        // Our series array that contains series objects or in this case series data arrays
        series: [
            [5, 2, 4, 2, 0]
        ]
    };

    var data2 = {
        series: [5, 3, 4]
    };
    var sum = function (a, b) { return a + b };


    if (type === 'Line') {
        // Create a new line chart object where as first parameter we pass in a selector
        // that is resolving to our chart container element. The Second parameter
        // is the actual data object.
        new Chartist.Line("#" + id, data);
    }
    else if (type === 'Bar') {
        // Create a new line chart object where as first parameter we pass in a selector
        // that is resolving to our chart container element. The Second parameter
        // is the actual data object.
        new Chartist.Bar("#" + id, data);
    }
    else if (type === 'Pie') {

        // Create a new line chart object where as first parameter we pass in a selector
        // that is resolving to our chart container element. The Second parameter
        // is the actual data object.
        new Chartist.Pie("#" + id, data2, {
            labelInterpolationFnc: function (value) {
                return Math.round(value / data2.series.reduce(sum) * 100) + '%';
                }
            });
    }
}

export function showChartLine(id, data) {
    new Chartist.Line("#" + id, data);
}

export function showChartBar(id, data) {
    new Chartist.Bar("#" + id, data);
}

export function showChartPie(id, data) {
    var sum = function (a, b) { return a + b };

    new Chartist.Pie("#" + id, data, {
        labelInterpolationFnc: function (value) {
            return Math.round(value / data.series.reduce(sum) * 100) + '%';
        }
    });
} 