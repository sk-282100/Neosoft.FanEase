
$(document).ready(function () {
    $("#viewerEmailId").blur(function () {
        var emailId = $('#viewerEmailId').val();

        $.ajax({
            beforeSend: function () {
                $('.ajax-loader').css("visibility", "visible");
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
                $('.ajax-loader').css("visibility", "hidden");
            },
            error: function (error) {
                alert("Some Error occurred! Please reload the Page");
            }
        });
    });

});