var setDefaultActive = function () {
    var path = window.location.pathname;
    console.log("hello");
    var element = $(".nav-item a[href='" + path + "']");

    element.addClass("myactive");
}



$(document).ready(function() {
    setDefaultActive();
});