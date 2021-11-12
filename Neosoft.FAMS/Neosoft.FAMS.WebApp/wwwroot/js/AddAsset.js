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

function onContentType() {
    var val = document.getElementById('ContentType').value;
    console.log(val);
    if (val == "1") {
        console.log("if");
        document.getElementById('hideMe1').style.display = "none";
        document.getElementById('hideMe').style.display = "inline";
    } else {
        document.getElementById('hideMe').style.display = "none";
        document.getElementById('hideMe1').style.display = "inline";
    }
}