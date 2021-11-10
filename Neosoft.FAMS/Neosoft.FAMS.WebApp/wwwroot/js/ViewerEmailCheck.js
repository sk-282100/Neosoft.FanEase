
$(document).ready(function () {
    $("#viewerEmailId").blur(function () {
        var emailId = $('#viewerEmailId').val();

        $.ajax({
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
            error: function (error) {
                alert("Some Error occurred! Please reload the Page");
            }
        });
    });

});