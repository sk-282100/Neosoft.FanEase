
$(document).ready(function () {
    $("#creatorEmailId").blur(function () {
        console.log("hello");
        var emailId = $('#creatorEmailId').val();

        $.ajax({
            url: "/Admin/checkForEmailExist?email="+emailId,
            type: 'GET',
            beforeSend: function () {
                $('.ajax-loadero').css("visibility", "visible");
            },
            success: function (data) {
                console.log(data);
                if (data) {
                    $('#emailSpan').text("Email already Exist");
                } else {
                    $('#emailSpan').text("");
                }
            },
            complete: function () {
                $('.ajax-loadero').css("visibility", "hidden");
            },
            error: function (error) {
                alert("Some Error occurred! Please reload the Page");
            }
        });
    });

});

function CheckFileSize(input) {
    if (input.files && input.files[0]) {
        var ext = $(input).val().split('.').pop().toLowerCase();
        var result = $.inArray(ext, ['PNG', 'png', 'JPG', 'JPEG', 'jpg', 'jpeg']);
        if (input.files && input.files[0] && result >= 0) {
        var fileSize = $(input)[0].files[0].size;
        if (fileSize <= 1000000) {
            $('#errorFileSize').text("");
        } else {
            var $el = $('#formFileMultiple');
            $el.wrap('<form>').closest('form').get(0).reset();
            $el.unwrap();
            $('#boldTag').text("");
            $('#errorFileSize').text("Max allowed File Size is 1 MB");

          }
        }
        else {
            var $el = $('#formFileMultipleS');
            $el.wrap('<form>').closest('form').get(0).reset();
            $el.unwrap();
            $('#errorFileSize').text("Only png, jpg and jpeg Images allowed");
            setTimeout(
                function () {
                    $('#errorFileSize').text("");
                }, 10000);
        }
    }
}