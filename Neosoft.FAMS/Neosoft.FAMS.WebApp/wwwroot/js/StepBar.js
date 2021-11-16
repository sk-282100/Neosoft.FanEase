var setDefaultActive = function () {
    var path = window.location.pathname;
    if (path.includes("Video")) {
        path = "/Creator/VideoTable";
        var element = $(".nav-item a[href='" + path + "']");
        element.addClass("myactive");
    }
    else if (path.includes("Campaign")) {
        path = "/Creator/AddCampaignView";
        var element = $(".nav-item a[href='" + path + "']");
        element.addClass("myactive");
        document.getElementById('bar1').style.backgroundColor = "#56baed";

    } else if (path.includes("Asset")) {
        path = "/Creator/AddAsset";
        var element = $(".nav-item a[href='" + path + "']");
        element.addClass("myactive");
        document.getElementById('bar1').style.backgroundColor = "#56baed";
        document.getElementById('bar2').style.backgroundColor = "#56baed";

    }

}


$(document).ready(function () {
    setDefaultActive();
});

