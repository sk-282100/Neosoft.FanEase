var countrydata = [];
var Statedata = [];
var Citydata = [];

$(document).ready(function () {
    var countryId = $('#CountryId').val();
    var stateId = $('#StateId').val();
    var cityId = $('#CityId').val();

    $.ajax({
        type: 'GET',
        url: '/Admin/GetCountry',
        async: false,
        contentType: 'application/json',
        success: function (data) {
            countrydata = data;
            $.each(data,
                function (id, text) {
                    $('#formCountry').append(
                        $('<option></option>').val(text.id).html(text.text)
                    );
                });
        }
    });
    
    $(`select option[value='${countryId}']`).attr("selected", "selected");

    $.ajax({
        type: 'GET',
        url: "/Admin/GetStates/"+countryId,
        async: false,
        contentType: 'application/json',
        success: function (data) {
            console.log(data);
            Statedata = data;
            $.each(data, function (id, text) {
                if (text != null) {
                    $('#formState').append(
                        $('<option></option>').val(text.id).html(text.text)
                    );
                }
            });
        }
    });
    $.ajax({
        type: 'GET',
        url: "/Admin/GetCity/5",
        async: false,
        contentType: 'application/json',
        success: function (data) {
            console.log(data);
            Citydata = data;
            $.each(data, function (id, text) {
                if (text != null) {
                    $('#formCity').append(
                        $('<option></option>').val(text.id).html(text.text)
                    );
                }
            });
        }
    });
    $(`#formCity option[value='${cityId}']`).attr("selected", "selected");


    $('#formCountry').change(function () {
        $('#formState').empty();
        var countryId = $('#formCountry').val();
        console.log(countryId);
        $.ajax({
            type: 'GET',
            url: "/Admin/GetStates/" + countryId.toString(),
            async: false,
            contentType: 'application/json',
            success: function (data) {
                console.log(data);
                Statedata = data;
                $.each(data, function (id, text) {
                    if (text != null) {
                        $('#formState').append(
                            $('<option></option>').val(text.id).html(text.text)
                        );
                    }
                });
            }
        });
    });

    $('#formState').change(function () {
        $('#formCity').empty();
        var stateId = $('#formState').val();
        console.log(stateId);
        $.ajax({
            type: 'GET',
            url: "/Admin/GetCity/" + stateId.toString(),
            async: false,
            contentType: 'application/json',
            success: function (data) {
                console.log(data);
                Citydata = data;
                $.each(data, function (id, text) {
                    if (text != null) {
                        $('#formCity').append(
                            $('<option></option>').val(text.id).html(text.text)
                        );
                    }
                });
            }
        });

    });

});
