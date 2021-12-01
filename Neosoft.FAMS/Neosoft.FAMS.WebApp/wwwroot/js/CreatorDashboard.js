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

    $(".progress").each(function() {

        var value = $(this).attr('data-value');
        var datas = $(this).attr('data-value-temp');
        var left = $(this).find('.progress-left .progress-bar');
        var right = $(this).find('.progress-right .progress-bar');

        if (value > 0) {
            var temp = value / 2;
            if (datas <= temp) {
                right.css('transform', 'rotate(' + percentageToDegrees(datas, value) + 'deg)');
            } else {
                right.css('transform', 'rotate(180deg)');
                left.css('transform', 'rotate(' + percentageToDegrees((datas - temp), value) + 'deg)');
            }
        }

    });

    function percentageToDegrees(percentage,value) {

        return 360 * percentage / value;

    }

});


$(document).ready(function () {
    var CreatorId = $('#CreatorId').val();
    var ddlYears = document.getElementById("selectYear");


    var currentYear = (new Date()).getFullYear();


    for (var i = currentYear; i >= 1980; i--) {
        var option = document.createElement("OPTION");
        option.innerHTML = i;
        option.value = i;
        ddlYears.appendChild(option);
    }


    $.ajax({
        type: 'GET',
        url: "/Creator/yearlyStats/"+ CreatorId.toString() + "/"+ currentYear.toString(),
        //url: "https://localhost:44330/api/ContentCreatorDashboard/GetYearlyStatistics/" + CreatorId + "?years=" + currentYear +"&api-version=1",
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
                    title: " No of Videos Uploaded",
                    maximum: 100
                },
                data: [{
                    type: "line",
                    color: "orangered",
                    indexLabelFontSize: 16,
                    dataPoints: [
                        { y: chartdata[0], label: "January" },
                        { y: chartdata[1], label: "February" },
                        { y: chartdata[2], label: "March" },
                        { y: chartdata[3], label: "April" },
                        { y: chartdata[4], label: "May" },
                        { y: chartdata[5], label: "June" },
                        { y: chartdata[6], label: "July" },
                        { y: chartdata[7], label: "August" },
                        { y: chartdata[8], label: "September" },
                        { y: chartdata[9], label: "October" },
                        { y: chartdata[10], label: "November" },
                        { y: chartdata[11], label: "December" }
                    ]
                }]
            });
            chart.render();
        }
    });



    $('#selectYear').change(function () {
        var year = document.getElementById("selectYear").value;
        $.ajax({
            type: 'GET',
            url: "/Creator/yearlyStats/" + CreatorId.toString() + "/" + year.toString(),
            //url: "https://localhost:44330/api/ContentCreatorDashboard/GetYearlyStatistics/" + CreatorId + "?years=" + year + "&api-version=1",

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
                        title: "Videos Uploaded",
                        maximum: 100
                    },
                    data: [{
                        type: "line",
                        color: "orangered",
                        indexLabelFontSize: 16,
                        dataPoints: [
                            { y: chartdata[0], label: "January" },
                            { y: chartdata[1], label: "February" },
                            { y: chartdata[2], label: "March" },
                            { y: chartdata[3], label: "April" },
                            { y: chartdata[4], label: "May" },
                            { y: chartdata[5], label: "June" },
                            { y: chartdata[6], label: "July" },
                            { y: chartdata[7], label: "August" },
                            { y: chartdata[8], label: "September" },
                            { y: chartdata[9], label: "October" },
                            { y: chartdata[10], label: "November" },
                            { y: chartdata[11], label: "December" }
                        ]
                    }]
                });
                chart.render();
            }
        });


    });

});










