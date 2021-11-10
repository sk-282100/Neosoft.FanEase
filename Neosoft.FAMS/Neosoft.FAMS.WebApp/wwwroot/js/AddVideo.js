﻿function readURL(input) {
    if (input.files && input.files[0]) {
        var fileSize = $(input)[0].files[0].size;
        if (fileSize <= 1000000) {
            $('#errorFileSize').text("");
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#thumbnail').attr('src', e.target.result)
                    .width(150)
                    .height(100);
            };
            reader.readAsDataURL(input.files[0]);
        }
        else {
            var $el = $('#videoThumbnail');
            $el.wrap('<form>').closest('form').get(0).reset();
            $el.unwrap();
            $('#thumbnail').attr('src', null);
            $('#errorFileSize').text("Max File is 1 MB");
            
        }
    }
}

