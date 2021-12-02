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


$(document).ready(function() {
    var CreatorId = $('#CreatorId').val();
    var ddlYears = document.getElementById("selectYear");


    var currentYear = (new Date()).getFullYear();


    for (var i = currentYear; i >= 1980; i--) {
        var option = document.createElement("OPTION");
        option.innerHTML = i;
        option.value = i;
        ddlYears.appendChild(option);
    }

    var LiveData = [];

    $.ajax({
        type: 'GET',
        url: "/Creator/yearlyLiveStats/" + CreatorId.toString() + "/" + currentYear.toString(),
        async: false,
        contentType: 'application/json',
        success: function(data) {
            chartdata = data;
            LiveData = data;
        }
    });

    $.ajax({
        type: 'GET',
        url: "/Creator/yearlyStats/" + CreatorId.toString() + "/" + currentYear.toString(),
        //url: "https://localhost:44330/api/ContentCreatorDashboard/GetYearlyStatistics/" + CreatorId + "?years=" + currentYear +"&api-version=1",
        async: false,
        contentType: 'application/json',
        success: function(data) {
            chartdata = data;
            var chart = new CanvasJS.Chart("chartContainer",
                {
                    animationEnabled: true,
                    theme: "light2",
                    axisX: {
                        titleFontColor: "black",
                        title: "Months"
                    },
                    axisY: {
                        titleFontColor: "black",
                        title: " No of Videos Uploaded",
                        maximum: 100
                    },
                    legend: {
                        cursor: "pointer",
                        verticalAlign: "top",
                        horizontalAlign: "center",
                        dockInsidePlotArea: true

                    },
                    toolTip: {
                        shared: true
                    },
                    data: [
                        {
                            type: "line",
                            axisYType: "primary",
                            name: "Videos Uploaded",
                            showInLegend: true,

                            markerSize: 1,
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
                        },
                        {
                            type: "line",
                            axisYType: "primary",
                            name: "Live Videos",
                            showInLegend: true,
                            markerSize: 1,
                            color: "orangered",

                            dataPoints: [
                                { y: LiveData[0], label: "January" },
                                { y: LiveData[1], label: "February" },
                                { y: LiveData[2], label: "March" },
                                { y: LiveData[3], label: "April" },
                                { y: LiveData[4], label: "May" },
                                { y: LiveData[5], label: "June" },
                                { y: LiveData[6], label: "July" },
                                { y: LiveData[7], label: "August" },
                                { y: LiveData[8], label: "September" },
                                { y: LiveData[9], label: "October" },
                                { y: LiveData[10], label: "November" },
                                { y: LiveData[11], label: "December" }
                            ]
                        }
                    ]
                });
            chart.render();
        }
    });


    $('#selectYear').change(function() {
        var year = document.getElementById("selectYear").value;

        $.ajax({
            type: 'GET',
            url: "/Creator/yearlyLiveStats/" + CreatorId.toString() + "/" + year.toString(),
            async: false,
            contentType: 'application/json',
            success: function(data) {
                chartdata = data;
                LiveData = data;
            }
        });


        $('#selectYear').change(function() {
            var year = document.getElementById("selectYear").value;
            $.ajax({
                type: 'GET',
                url: "/Creator/yearlyStats/" + CreatorId.toString() + "/" + year.toString(),
                //url: "https://localhost:44330/api/ContentCreatorDashboard/GetYearlyStatistics/" + CreatorId + "?years=" + year + "&api-version=1",

                async: false,
                contentType: 'application/json',
                success: function(data) {
                    chartdata = data;
                    var chart = new CanvasJS.Chart("chartContainer",
                        {
                            animationEnabled: true,
                            theme: "light2",

                            axisX: {
                                title: "Months"

                            },
                            axisY: {
                                title: "No of Videos Uploaded",
                                maximum: 100
                            },
                            legend: {
                                cursor: "pointer",
                                verticalAlign: "top",
                                horizontalAlign: "center",
                                dockInsidePlotArea: true

                            },
                            toolTip: {
                                shared: true
                            },
                            data: [
                                {
                                    type: "line",
                                    axisYType: "primary",
                                    name: "Videos Uploaded",
                                    showInLegend: true,
                                    maximum: 100,
                                    markerSize: 1,
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
                                },
                                {
                                    type: "line",
                                    axisYType: "primary",
                                    name: "Live Videos",
                                    showInLegend: true,
                                    markerSize: 1,
                                    color: "orangered",
                                    maximum: 100,
                                    dataPoints: [
                                        { y: LiveData[0], label: "January" },
                                        { y: LiveData[1], label: "February" },
                                        { y: LiveData[2], label: "March" },
                                        { y: LiveData[3], label: "April" },
                                        { y: LiveData[4], label: "May" },
                                        { y: LiveData[5], label: "June" },
                                        { y: LiveData[6], label: "July" },
                                        { y: LiveData[7], label: "August" },
                                        { y: LiveData[8], label: "September" },
                                        { y: LiveData[9], label: "October" },
                                        { y: LiveData[10], label: "November" },
                                        { y: LiveData[11], label: "December" }
                                    ]

                                }
                            ]
                        });
                    chart.render();
                }
            });


        });
    });
});
    









