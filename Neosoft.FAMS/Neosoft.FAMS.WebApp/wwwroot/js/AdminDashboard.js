$(function () {

    $('#TV-form-link').click(function (e) {
        $("#TV-form").delay(100).fadeIn(100);
        $("#TC-form").fadeOut(100);
        $('#TC-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });
    $('#TC-form-link').click(function (e) {
        $("#TC-form").delay(100).fadeIn(100);
        $("#TV-form").fadeOut(100);
        $('#TV-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });

});

$(function () {

    $(".progress").each(function () {

        var value = $(this).attr('data-value');
        var left = $(this).find('.progress-left .progress-bar');
        var right = $(this).find('.progress-right .progress-bar');

        if (value > 0) {
            if (value <= 50) {
                right.css('transform', 'rotate(' + percentageToDegrees(value) + 'deg)')
            } else {
                right.css('transform', 'rotate(180deg)')
                left.css('transform', 'rotate(' + percentageToDegrees(value - 50) + 'deg)')
            }
        }

    })

    function percentageToDegrees(percentage) {

        return percentage / 100 * 360

    }

});

window.onload = function () {
    var options = {
        animationEnabled: true,
        title: {
            text: ""
        },
        axisX: {
            valueFormatString: "MMM"
        },
        axisY: {
            title: "Views",
            prefix: ""
        },
        data: [{
            yValueFormatString: "###",
            xValueFormatString: "MMMM",
            type: "spline",
            color: "#56baed",
            dataPoints: [
                { x: new Date(2017, 0), y: 25060 },
                { x: new Date(2017, 1), y: 27980 },
                { x: new Date(2017, 2), y: 33800 },
                { x: new Date(2017, 3), y: 49400 },
                { x: new Date(2017, 4), y: 40260 },
                { x: new Date(2017, 5), y: 33900 },
                { x: new Date(2017, 6), y: 48000 },
                { x: new Date(2017, 7), y: 31500 },
                { x: new Date(2017, 8), y: 32300 },
                { x: new Date(2017, 9), y: 42000 },
                { x: new Date(2017, 10), y: 52160 },
                { x: new Date(2017, 11), y: 49400 }
            ]
        }]
    };
    $("#chartContainer").CanvasJSChart(options);
}