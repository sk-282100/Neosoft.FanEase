
$(document).ready(function () {
    $("#creatorEmailId").blur(function () {
        console.log("hello");
        var emailId = $('#creatorEmailId').val();

        $.ajax({
            url: "https://localhost:44330/api/ContentCreator/getCreatorByEmail?username=" + emailId + "&api-version=1",
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