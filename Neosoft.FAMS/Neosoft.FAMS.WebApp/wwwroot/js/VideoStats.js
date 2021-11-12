var likes = 0;
var dislikes = 0;
$(document).ready(function () {
    //var videoId = document.getElementById("#videoId").value;

    var videoId = $('#videoId').val();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44330/Likes/' + videoId + '?api-version=1',
        async: false,
        contentType: 'application/json',
        success: function (data) {
            likes = data;
            $('#like').text(likes);
        }
    });

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44330/Disikes/6?api-version=1',
        async: false,
        contentType: 'application/json',
        success: function (data) {
            likes = data;
            $('#dislike').text(dislikes);
        }
    });

});