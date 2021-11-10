function readURL(input) {
    if (input.files && input.files[0]) {
        var fileSize = $(input)[0].files[0].size;
        if (fileSize <= 1000000) {
            $('#errorFileSize').text("");
            var reader = new FileReader();
            reader.readAsDataURL(input.files[0]);
        }
        else {
            var $el = $('#formFileMultiple');
            $el.wrap('<form>').closest('form').get(0).reset();
            $el.unwrap();
            $('#errorFileSize').text("Max File is 1 MB");

        }
    }
}