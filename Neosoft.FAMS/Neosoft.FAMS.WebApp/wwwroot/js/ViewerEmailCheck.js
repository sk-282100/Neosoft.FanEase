
$(document).ready(function () {
    $("#viewerEmailId").blur(function () {
        var emailId = $('#viewerEmailId').val();

        $.ajax({
            url: "https://localhost:44330/api/Viewer/getViewerByEmail?username=" + emailId + "&api-version=1",
            type: 'GET',
            success: function (data) {
                console.log(data);
                if (data != null) {
                    $('#emailSpan').text("Email already Exist");
                }
            },
            error: function (error) {
                alert("error" + error);
            }
        });
    });

});