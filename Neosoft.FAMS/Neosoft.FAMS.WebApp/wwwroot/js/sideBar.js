var setDefaultActive = function () {
    var path = window.location.pathname;
    if (path.includes("Creator")) {
        path = "/Admin/CreatorsList";
    }
    else if (path.includes("Viewer")) {
        path = "/Admin/ViewerList";
    }
    console.log("hello");
    var element = $(".nav-item a[href='" + path + "']");

    element.addClass("myactive");
}



$(document).ready(function() {
    setDefaultActive();
});