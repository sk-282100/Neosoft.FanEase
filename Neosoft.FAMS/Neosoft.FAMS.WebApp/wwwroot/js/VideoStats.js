var likes = 0;
var dislikes = 0;
$(document).ready(function () {
    //var videoId = document.getElementById("#videoId").value;
    //https://localhost:44330/Likes/6?viewerId=5&api-version=1
    var videoId = $('#videoId').val();
    var viewerId = $('#viewerId').val();
    $('#like').click(function () {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44330/Likes/' + videoId + '?viewerId=' + viewerId + '&api-version=1',
            async: false,
            contentType: 'application/json',
            success: function (data) {
                likes = data;
                $('#like').text(likes);
            }
        });
    });
    $('#like').change(function () {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44330/Likes/' + videoId + '?viewerId=' + viewerId + '&api-version=1',
            async: false,
            contentType: 'application/json',
            success: function (data) {
                likes = data;
                $('#like').text(likes);
            }
        });
    });



    $('#dislike').click(function () {
        $.ajax({
            type: 'GET',
            //https://localhost:44330/Disikes/6?viewerId=2&api-version=1
            url: 'https://localhost:44330/Disikes/' + videoId + '?viewerId=' + viewerId + '&api-version=1',
            async: false,
            contentType: 'application/json',
            success: function (data) {
                dislikes = data;
                $('#dislike').text(dislikes);
            }
        });
    });
});