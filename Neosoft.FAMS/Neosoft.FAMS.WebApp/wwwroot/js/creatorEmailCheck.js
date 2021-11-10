
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

function CheckFileSize(input) {
    if (input.files && input.files[0]) {
        var fileSize = $(input)[0].files[0].size;
        if (fileSize <= 1000000) {
            $('#errorFileSize').text("");
        } else {
            var $el = $('#formFileMultiple');
            $el.wrap('<form>').closest('form').get(0).reset();
            $el.unwrap();
            $('#boldTag').text("");
            $('#errorFileSize').text("Max File Size is 1 MB");

        }
    }
}