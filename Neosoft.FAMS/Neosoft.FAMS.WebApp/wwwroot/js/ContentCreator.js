var countrydata = [];
var Statedata = [];
var Citydata = [];

$(document).ready(function () {

    $.ajax({
        type: 'GET',
        url: '/Admin/GetCountry',
        async: false,
        contentType: 'application/json',
        success: function (data) {
            countrydata = data;
            $.each(data,
                function(id, text) {
                    $('#formCountry').append(
                        $('<option></option>').val(text.id).html(text.text)
                    );
                });
        }
    });
    $.ajax({
        type: 'GET',
        url: "GetStates/1",
        async: false,
        contentType: 'application/json',
        success: function (data) {
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
        url: "GetCity/42",
        async: false,
        contentType: 'application/json',
        success: function (data) {
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

    $('#formCountry').change(function () {
        $('#formState').empty();
        var countryId = $('#formCountry').val();
        console.log(countryId);
        $.ajax({
            type: 'GET',
            url: "GetStates/"+countryId.toString(),
            async: false,
            contentType: 'application/json',
            success: function (data) {
            
            Statedata = data;
            $.each(data,function(id, text) {
                    if (text != null) {
                        $('#formState').append(
                            $('<option></option>').val(text.id).html(text.text)
                        );
                    }
                });
            }
        });
    });

    $('#formState').change(function() {
        $('#formCity').empty();
        var stateId = $('#formState').val();
        
        $.ajax({
            type: 'GET',
            url: "GetCity/" + stateId.toString(),
            async: false,
            contentType: 'application/json',
            success: function (data) {
               
                Citydata = data;
                $.each(data, function(id, text) {
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
