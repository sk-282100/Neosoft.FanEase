var setDefaultActive = function () {
    var path = window.location.pathname;
    
    if (path.includes("Campaign")) {
        path = "/Creator/AddCampaignView";
        document.getElementById('bar1').style.backgroundColor = "#56baed";
    }
    else if (path.includes("Asset")) {
        path = "/Creator/AddAsset";
        document.getElementById('bar1').style.backgroundColor = "#56baed";
        document.getElementById('bar2').style.backgroundColor = "#56baed";
    }
    
}


$(document).ready(function () {
    setDefaultActive();
});












//function myFunction(id) {
//    if (id == "bar1") {
//        document.getElementById(id).style.backgroundColor = "#56baed";
//    }
//    else {
//        document.getElementById(id).style.backgroundColor = "white";
//    }

//}

//function myFunction1(id1, id2) {
//    if (id1 == "bar1" && id2 == "bar2") {
//        document.getElementById(id1).style.backgroundColor = "#56baed";
//        document.getElementById(id2).style.backgroundColor = "#56baed";
//    }
//    else {
//        document.getElementById(id1).style.backgroundColor = "white";
//    }

//}