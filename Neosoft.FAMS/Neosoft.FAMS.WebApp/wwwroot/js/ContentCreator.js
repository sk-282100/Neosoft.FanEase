﻿var countrydata = [];
var Statedata = [];
var Citydata = [];

$(document).ready(function () {

    $.ajax({
        type: 'GET',
        beforeSend: function () {
            $('.ajax-loader').css("visibility", "visible");
        },
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
        },
        complete: function () {
            $('.ajax-loader').css("visibility", "hidden");
        }
    });
    $.ajax({
        type: 'GET',
        beforeSend: function () {
            $('.ajax-loader').css("visibility", "visible");
        },
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
        },
        complete: function () {
            $('.ajax-loader').css("visibility", "hidden");
        }
    });
    $.ajax({
        type: 'GET',
        beforeSend: function () {
            $('.ajax-loader').css("visibility", "visible");
        },
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
        },
        complete: function () {
            $('.ajax-loader').css("visibility", "hidden");
        }
    });

    $('#formCountry').change(function () {
        $('#formState').empty();
        var countryId = $('#formCountry').val();
        $.ajax({
            type: 'GET',
            beforeSend: function () {
                $('.ajax-loader').css("visibility", "visible");
            },
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
                    if (stateId > 0) {
                        $(`#formState option[value="${stateId}"]`).attr("selected", "selected");
                    }

                });
            },
            complete: function () {
                $('.ajax-loader').css("visibility", "hidden");
            }
        });
    });
    var countryId = $('#countryValue').val();
    if (countryId > 0) {
        $(`#formCountry option[value="${countryId}"]`).attr("selected", "selected");
        $("#formCountry").trigger("change");
    }
  

    $('#formState').change(function() {
        $('#formCity').empty();
        var stateId = $('#formState').val();
        
        $.ajax({
            type: 'GET',
            beforeSend: function () {
                $('.ajax-loader').css("visibility", "visible");
            },
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
            },
            complete: function () {
                $('.ajax-loader').css("visibility", "hidden");
            }
        });

    });
    var stateId = $('#stateValue').val();
    if (stateId > 0) {
        $(`#formState option[value="${stateId}"]`).attr("selected", "selected");
        $("#formState").trigger("change");
    }

    var cityId = $('#cityValue').val();
    if(cityId>0)
        $(`#formCity option[value="${cityId}"]`).attr("selected", "selected");

    var status = $('#statusValue').val();
    $(`.statusClass input[value="${status}"]`).attr("checked", true);

   /* var imgPath = $('#imgValue').val();
    document.getElementById('formFileMultipleS').value = imgPath;*/
});
