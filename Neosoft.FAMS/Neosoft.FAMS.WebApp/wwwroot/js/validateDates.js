jQuery.validator.addMethod("dateNotValid",
    function (value, element, param) {
        var d = new Date().toLocaleString();
        var year = new Date().getFullYear();
        var hour = new Date().getHours();
        var min = new Date().getMinutes();

        var data = d.split('/');
        var todayDate = year + "-" + data[0] + "-" + data[1] + "T" + hour + ":" + min;
        var selectedDate = value.toLocaleString();
        if (selectedDate < todayDate) {
            return false;
        }
        else {
            return true;
        }
    });

jQuery.validator.unobtrusive.adapters.addBool("dateNotValid");