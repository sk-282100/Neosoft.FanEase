var likes = 0;
var dislikes = 0;
var views = 0;
$(document).ready(function () {
    //var videoId = document.getElementById("#videoId").value;
    //https://localhost:44330/Likes/6?viewerId=5&api-version=1
    var videoId = $('#videoId').val();
    var viewerId = $('#viewerId').val();
    $('#like').click(function () {
        $.ajax({
            type: 'GET',
            url: "/VideoViewer/GetLikes?videoId=" + videoId + "&viewerId="+viewerId,
            async: false,
            contentType: 'application/json',
            success: function (data) {

                likes = data[1];
                dislikes = data[0];
                $('#likeSpan').text(likes);
                $('#dislikeSpan').text(dislikes);
                var element = $('#likeIcon');
                element.addClass("fas fa-thumbs-up");

            }
        });
    });



    $('#dislike').click(function () {
        $.ajax({
            type: 'GET',
            url: "/VideoViewer/GetDisLikes?videoId=" + videoId + "&viewerId=" + viewerId,
            async: false,
            contentType: 'application/json',
            success: function (data) {
                dislikes = data[0];
                likes = data[1];
                $('#likeSpan').text(likes);
                $('#dislikeSpan').text(dislikes);
            }
        });
    });
    $('.vjs-big-play-button,.vjs-icon-placeholder').click(function () {
        $.ajax({
            type: 'GET',
           //https://localhost:44330/Views/6?viewerId=2&api-version=1
            url: "/VideoViewer/GetViews?videoId=" + videoId + "&viewerId=" + viewerId,
            async: false,
            contentType: 'application/json',
            success: function (data) {
                views = data
                $('#views').text(views);
            }
        });
    });
    


});