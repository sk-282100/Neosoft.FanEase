jQuery.validator.addMethod("dateNotValid",
    function (value, element, param) {
        var d = new Date().toLocaleString();
        var selectedDate = value.toLocaleString();
        if (selectedDate < d.getDate()) {
            return false;
        }
        else {
            return true;
        }
    });

jQuery.validator.unobtrusive.adapters.addBool("dateNotValid");