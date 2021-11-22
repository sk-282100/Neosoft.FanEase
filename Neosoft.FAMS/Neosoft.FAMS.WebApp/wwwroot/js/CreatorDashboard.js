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

        return 360 * percentage / 100;;

    }

});




$(document).ready(function () {
    
    $.ajax({
        type: 'GET',
        url: "https://localhost:44330/api/ContentCreatorDashboard/GetYearlyStatistics/1?years=2021&api-version=1",
        async: false,
        contentType: 'application/json',
        success: function (data) {
            chartdata = data;
            var chart = new CanvasJS.Chart("chartContainer", {
                animationEnabled: true,
                theme: "light2",
                title: {
                    text: "Statistics"
                },
                axisX: {
                    title: "Months"

                },
                axisY: {
                    title: "Video Uploaded"
                },
                data: [{
                    type: "line",
                    indexLabelFontSize: 16,
                    dataPoints: [
                        { y: chartdata[0] },
                        { y: chartdata[1] },
                        { y: chartdata[2] },
                        { y: chartdata[3] },
                        { y: chartdata[4] },
                        { y: chartdata[5] },
                        { y: chartdata[6] },
                        { y: chartdata[7] },
                        { y: chartdata[8] },
                        { y: chartdata[9] },
                        { y: chartdata[10] },
                        { y: chartdata[11] }
                    ]
                }]
            });
            chart.render();
        }
    });

    var ddlYears = document.getElementById("selectYear");


    var currentYear = (new Date()).getFullYear();


    for (var i = currentYear; i >= 1980; i--) {
        var option = document.createElement("OPTION");
        option.innerHTML = i;
        option.value = i;
        ddlYears.appendChild(option);
    }


    $('#selectYear').change(function () {
        var year = document.getElementById("selectYear").value;
        $.ajax({
            type: 'GET',
            url: "https://localhost:44330/api/AdminDashboard/GetYearlyStatistics?years=2021&api-version=1",
            async: false,
            contentType: 'application/json',
            success: function (data) {
                chartdata = data;
                var chart = new CanvasJS.Chart("chartContainer", {
                    animationEnabled: true,
                    theme: "light2",
                    title: {
                        text: "Statistics"
                    },
                    axisX: {
                        title: "Months"

                    },
                    axisY: {
                        title: "Video Uploaded"
                    },
                    data: [{
                        type: "line",
                        indexLabelFontSize: 16,
                        dataPoints: [
                            { x: "January", y: chartdata[0] },
                            { y: chartdata[1] },
                            { y: chartdata[2] },
                            { y: chartdata[3] },
                            { y: chartdata[4] },
                            { y: chartdata[5] },
                            { y: chartdata[6] },
                            { y: chartdata[7] },
                            { y: chartdata[8] },
                            { y: chartdata[9] },
                            { y: chartdata[10] },
                            { y: chartdata[11] }
                        ]
                    }]
                });
                chart.render();
            }
        });


    });

});