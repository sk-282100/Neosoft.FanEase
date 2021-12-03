﻿var likes = 0;
var dislikes = 0;
var views = 0;
$(document).ready(function () {
    //var videoId = document.getElementById("#videoId").value;
    //https://localhost:44330/Likes/6?viewerId=5&api-version=1
    var status = $("#likeStatus").val();
    var videoId = $('#videoId').val();
    var viewerId = $('#viewerId').val();
    var likeId = $('#likeIcon');
    var dislikeId = $('#dislikeIcon');
    if (status == "True") {
        $('#likeIcon').removeClass();
        likeId.addClass("fas fa-thumbs-up");
    }
    else if (status == "False") {
        $('#dislikeIcon').removeClass();
        dislikeId.addClass("fas fa-thumbs-down");
    }


    $('#like').click(function () {
        $.ajax({
            type: 'GET',
            beforeSend: function () {
                $('.ajax-loader').css("visibility", "visible");
            },
            url: "/VideoViewer/GetLikes?videoId=" + videoId + "&viewerId=" + viewerId,
            async: false,
            contentType: 'application/json',
            success: function (data) {

                likes = data[1];
                dislikes = data[0];
                $('#likeSpan').text(likes);
                $('#dislikeSpan').text(dislikes);

                var elementLike = $('#likeIcon');
                var elementClassLike = $('#likeIcon').attr("class");

                var elementdisLike = $('#dislikeIcon');
                var elementClassdisLike = $('#dislikeIcon').attr("class");

                if (elementClassLike == "fa fa-thumbs-o-up" && elementClassdisLike == "fa fa-thumbs-o-down") {
                    elementLike.removeClass();
                    elementLike.addClass("fas fa-thumbs-up");

                }
                else if (elementClassLike == "fas fa-thumbs-up" && elementClassdisLike == "fa fa-thumbs-o-down") {
                    elementLike.removeClass();
                    elementLike.addClass("fa fa-thumbs-o-up");
                }
                else if (elementClassLike == "fa fa-thumbs-o-up" && elementClassdisLike == "fas fa-thumbs-down") {
                    elementdisLike.removeClass();
                    elementLike.removeClass();
                    elementLike.addClass("fas fa-thumbs-up");
                    elementdisLike.addClass("fa fa-thumbs-o-down");

                }
            },
            complete: function () {
                $('.ajax-loader').css("visibility", "hidden");
            }
        });
    });



    $('#dislike').click(function () {
        $.ajax({
            type: 'GET',
            beforeSend: function () {
                $('.ajax-loader').css("visibility", "visible");
            },
            url: "/VideoViewer/GetDisLikes?videoId=" + videoId + "&viewerId=" + viewerId,
            async: false,
            contentType: 'application/json',
            success: function (data) {
                dislikes = data[0];
                likes = data[1];
                $('#likeSpan').text(likes);
                $('#dislikeSpan').text(dislikes);

                var elementLike = $('#likeIcon');
                var elementClassLike = $('#likeIcon').attr("class");

                var elementdisLike = $('#dislikeIcon');
                var elementClassdisLike = $('#dislikeIcon').attr("class");

                console.log(elementClassdisLike);
                if (elementClassdisLike == "fa fa-thumbs-o-down" && elementClassLike == "fa fa-thumbs-o-up") {
                    elementdisLike.removeClass();
                    elementdisLike.addClass("fas fa-thumbs-down");
                }
                else if ((elementClassdisLike == "fas fa-thumbs-down" && elementClassLike == "fa fa-thumbs-o-up")) {
                    elementdisLike.removeClass();
                    elementdisLike.addClass("fa fa-thumbs-o-down");
                }
                else if (elementClassdisLike == "fa fa-thumbs-o-down" && elementClassLike == "fas fa-thumbs-up") {
                    elementdisLike.removeClass();
                    elementLike.removeClass();
                    elementLike.addClass("fa fa-thumbs-o-up");
                    elementdisLike.addClass("fas fa-thumbs-down");

                }
            },
            complete: function () {
                $('.ajax-loader').css("visibility", "hidden");
            }
        });
    });
    $('.vjs-icon-placeholder').click(function () {
        $.ajax({
            type: 'GET',
            beforeSend: function () {
                $('.ajax-loader').css("visibility", "visible");
            },
            //https://localhost:44330/Views/6?viewerId=2&api-version=1
            url: "/VideoViewer/GetViews?videoId=" + videoId + "&viewerId=" + viewerId,
            async: false,
            contentType: 'application/json',
            success: function (data) {
                views = data
                $('#views').text(views);
            },
            complete: function () {
                $('.ajax-loader').css("visibility", "hidden");
            }
        });

        //$.get("/VideoViewer/GetViews?videoId=", { videoId: videoId, viewerId:viewerId });
    });

    $('.vjs-big-play-button,').click(function () {
        $.ajax({
            type: 'GET',
            beforeSend: function () {
                $('.ajax-loader').css("visibility", "visible");
            },
            //https://localhost:44330/Views/6?viewerId=2&api-version=1
            url: "/VideoViewer/GetViews?videoId=" + videoId + "&viewerId=" + viewerId,
            async: false,
            contentType: 'application/json',
            success: function (data) {
                views = data
                $('#views').text(views);
            },
            complete: function () {
                $('.ajax-loader').css("visibility", "hidden");
            }
        });
    });

});
