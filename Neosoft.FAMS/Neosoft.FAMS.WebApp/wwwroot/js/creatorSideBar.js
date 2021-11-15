var setDefaultActive = function () {
    var path = window.location.pathname;
    if (path.includes("Video")) {
        path = "/Creator/VideoTable";
    }
    else if (path.includes("Campaign")) {
        path = "/Creator/AddCampaignView";
    }
    else if (path.includes("Asset")) {
        path = "/Creator/AddAsset";
    }
    else if (path.includes("Template")) {
        path = "/Template/TemplateList";
    }
    console.log("hello");
    var element = $(".nav-item a[href='" + path + "']");

    element.addClass("myactive");
}



$(document).ready(function () {
    setDefaultActive();
});