
$(document).ready(function () {
    $("#viewerEmailId").blur(function () {
        var emailId = $('#viewerEmailId').val();

        $.ajax({
            beforeSend: function () {
                loaderVisible();
            },
            url: "/Viewer/checkForEmailExist?email=" + emailId,
            type: 'GET',
            success: function (data) {
                console.log(data);
                if (data) {
                    $('#emailSpan').text("Email already Exist");
                } else {
                    $('#emailSpan').text("");
                }
            },
            complete: function () {
                loaderHide();
            },
            error: function (error) {
                ajaxErrorOccured();
            }
        });
    });

});