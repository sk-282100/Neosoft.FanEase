$(document).ready(function() {
    $.ajax({
        type: 'GET',
        url: '/Creator/GetAdvertisement',
        async: false,
        contentType: 'application/json',
        success: function (data) {
            
            $.each(data,
                function (id, text) {
                    $('#formCountry').append(
                        $('<option></option>').val(text.id).html(text.text)
                    );
                });
        }
    });
});