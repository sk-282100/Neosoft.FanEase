$(function () {

    $('#TV-form-link').click(function (e) {
        $("#TV-form").delay(100).fadeIn(100);
        $("#TC-form").fadeOut(100);
        $('#TC-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });
    $('#TC-form-link').click(function (e) {
        $("#TC-form").delay(100).fadeIn(100);
        $("#TV-form").fadeOut(100);
        $('#TV-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });

});

$(function () {

    $(".progress").each(function () {

        var value = $(this).attr('data-value');
        var left = $(this).find('.progress-left .progress-bar');
        var right = $(this).find('.progress-right .progress-bar');

        if (value > 0) {
            if (value <= 50) {
                right.css('transform', 'rotate(' + percentageToDegrees(value) + 'deg)')
            } else {
                right.css('transform', 'rotate(180deg)')
                left.css('transform', 'rotate(' + percentageToDegrees(value - 50) + 'deg)')
            }
        }

    })

    function percentageToDegrees(percentage) {

        return percentage / 100 * 360

    }

});


