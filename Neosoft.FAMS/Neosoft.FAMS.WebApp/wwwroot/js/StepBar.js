
function myFunction(id) {
    if (id == "bar1") {
        document.getElementById(id).style.backgroundColor = "#56baed";
    }
    else {
        document.getElementById(id).style.backgroundColor = "white";
    }

}

function myFunction1(id1, id2) {
    if (id1 == "bar1" && id2 == "bar2") {
        document.getElementById(id1).style.backgroundColor = "#56baed";
        document.getElementById(id2).style.backgroundColor = "#56baed";
    }
    else {
        document.getElementById(id1).style.backgroundColor = "white";
    }

}