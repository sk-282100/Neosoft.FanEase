jQuery.validator.addMethod("dateNotValid",
    function (value, element, param) {
        var d = new Date().toLocaleString();
        var year = new Date().getFullYear();

        var data = d.split('/');
        var todayDate = year + "-" + data[0] + "-" + data[1];
        var selectedDate = value.toLocaleString().split("T");
        var selected = selectedDate[0];
        if (Date.parse(selectedDate[0]) < Date.parse(todayDate)) {
            return false;
        }
        else {

            return true;
        }
    });

jQuery.validator.unobtrusive.adapters.addBool("dateNotValid");