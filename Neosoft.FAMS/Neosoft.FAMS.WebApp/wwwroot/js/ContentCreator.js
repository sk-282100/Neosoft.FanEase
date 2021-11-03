var countrydata = [];
$(document).ready(function () {
$.ajax({
    type: 'GET',
    url: '/Admin/GetCountry',
    async: false,
    contentType: 'application/json',
    success: function (data) {
        countrydata = data;
        $.each(data, function (id, text) {
            $('#formCountry').append(
                $('<option></option>').val(text.id).html(text.text)
            );
        })
    }
});

    $('#formCountry').change(function () {
        alert($('#formCountry').val());
    });
});
