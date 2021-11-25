var videodata = 0;
var Description = "";
$(document).ready(function () {
  
    $.ajax({
        type: 'GET',
        url: "/Viewer/GetVideos",
        async: false,
        contentType: 'application/json',
        success: function (data) {
            videodata = data;
            for (i = 0; i < (videodata.length); i++) {
                var temp = new Date(videodata[i].createdOn);
  
                var ye = new Intl.DateTimeFormat('en', { year: 'numeric' }).format(temp);
                var mo = new Intl.DateTimeFormat('en', { month: 'short' }).format(temp);
                var da = new Intl.DateTimeFormat('en', { day: '2-digit' }).format(temp);
                    $('#showTable').append
                        (`
                            <div id="column" class="col-md-12 col-lg-4 col-sm-3 mb-4">
                                <div class="card">
                                    <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i].videoId}">
                                        <img src="/Uploads/Creators/Videos/${videodata[i].videoImage}" class="card-img-top" style="height:250px;">
                                    </a>
                                    <div class="card-body text-center">
                                        <h3 class="card-title align-items-center d-flex justify-content-center">${videodata[i].title}</h3>
                                        <p class="card-text"><b>Uploaded On :</b> ${da}-${mo}-${ye}</p>
                                    </div>
                                </div>
                            </div>
                        `);
                }
        }
    });
    $('#selectVideo').click(function () {
        if ($('#selectVideo').val() == 1) {
            $.ajax({
                type: 'GET',
                url: "/Viewer/GetVideos",
                async: false,
                contentType: 'application/json',
                success: function (data) {
                    videodata = data;
                    $('#showTable').empty();
                    for (i = 0; i < (videodata.length); i++) {
                        var temp = new Date(videodata[i].createdOn);

                        var ye = new Intl.DateTimeFormat('en', { year: 'numeric' }).format(temp);
                        var mo = new Intl.DateTimeFormat('en', { month: 'short' }).format(temp);
                        var da = new Intl.DateTimeFormat('en', { day: '2-digit' }).format(temp);
                        
                        $('#showTable').append
                            (`
                            <div id="column" class="col-md-12 col-lg-4 col-sm-3 mb-4">
                                <div class="card">
                                    <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i].videoId}">
                                        <img src="/Uploads/Creators/Videos/${videodata[i].videoImage}" class="card-img-top" style="height:250px;">
                                    </a>
                                    <div class="card-body text-center">
                                        <h3 class="card-title align-items-center d-flex justify-content-center">${videodata[i].title}</h3>
                                        <p class="card-text"><b>Uploaded On :</b> ${da}-${mo}-${ye}</p>
                                    </div>
                                </div>
                            </div>
                        `);
                    }
                }
            });

        }
    });
    $('#selectVideo').click(function () {
        if ($('#selectVideo').val() == 2) {
            $.ajax({
                type: 'GET',
                url: "/Viewer/GetVideos",
                async: false,
                contentType: 'application/json',
                success: function (data) {
                    $('#showTable').empty();
                    videodata = data;
                    for (i = videodata.length-1; i >= 0; i--) {
                        var temp = new Date(videodata[i].createdOn);

                        var ye = new Intl.DateTimeFormat('en', { year: 'numeric' }).format(temp);
                        var mo = new Intl.DateTimeFormat('en', { month: 'short' }).format(temp);
                        var da = new Intl.DateTimeFormat('en', { day: '2-digit' }).format(temp);
                       
                        $('#showTable').append
                            (`
                            <div id="column" class="col-md-12 col-lg-4 col-sm-3 mb-4">
                                <div class="card">
                                    <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i].videoId}">
                                        <img src="/Uploads/Creators/Videos/${videodata[i].videoImage}" class="card-img-top" style="height:250px;">
                                    </a>
                                    <div class="card-body text-center">
                                        <h3 class="card-title  align-items-center d-flex justify-content-center">${videodata[i].title}</h3>
                                        <p class="card-text"><b>Uploaded On :</b> ${da}-${mo}-${ye}</p>
                                    </div>
                                </div>
                            </div>
                        `);
                    }
                }
            });
        }
    });


    $('#selectVideo').click(function () {
        if ($('#selectVideo').val() == 3) {
            $.ajax({
                type: 'GET',
                url: "/Viewer/GetTopLikedVideos",
                async: false,
                contentType: 'application/json',
                success: function (data) {
                    $('#showTable').empty();
                    videodata = data;
                    for (i = 0; i < (videodata.length); i++) {
                        var temp = new Date(videodata[i].createdOn);

                        var ye = new Intl.DateTimeFormat('en', { year: 'numeric' }).format(temp);
                        var mo = new Intl.DateTimeFormat('en', { month: 'short' }).format(temp);
                        var da = new Intl.DateTimeFormat('en', { day: '2-digit' }).format(temp);
                       
                        $('#showTable').append
                            (`
                            <div id="column" class="col-md-12 col-lg-4 col-sm-3 mb-4">
                                <div class="card">
                                    <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i].topVideoId}">
                                        <img src="/Uploads/Creators/Videos/${videodata[i].videoImage}" class="card-img-top" style="height:250px;">
                                    </a>
                                    <div class="card-body text-center">
                                        <h3 class="card-title">${videodata[i].title}</h3>
                                        <p class="card-text"><b>Uploaded On :</b> ${da}-${mo}-${ye}</p>
                                    </div>
                                </div>
                            </div>
                        `);
                    }
                }
            });

        }
    });


    $('#selectVideo').click(function () {
        if ($('#selectVideo').val() == 4) {
            $.ajax({
                type: 'GET',
                url: "/Viewer/topViewsVideo",
                async: false,
                contentType: 'application/json',
                success: function (data) {
                    $('#showTable').empty();
                    videodata = data;
                    for (i = 0; i < (videodata.length); i++) {
                        var temp = new Date(videodata[i].createdOn);
                        var ye = new Intl.DateTimeFormat('en', { year: 'numeric' }).format(temp);
                        var mo = new Intl.DateTimeFormat('en', { month: 'short' }).format(temp);
                        var da = new Intl.DateTimeFormat('en', { day: '2-digit' }).format(temp);
                     
                        $('#showTable').append
                            (`
                            <div id="column" class="col-md-12 col-lg-4 col-sm-3 mb-4">
                                <div class="card">
                                    <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i].topVideoId}">
                                        <img src="/Uploads/Creators/Videos/${videodata[i].videoImage}" class="card-img-top" style="height:250px;">
                                    </a>
                                    <div class="card-body text-center">
                                        <h3 class="card-title">${videodata[i].title}</h3>
                                        <p class="card-text"><b>Uploaded On :</b> ${da}-${mo}-${ye}</p>
                                    </div>
                                </div>
                            </div>
                        `);
                    }
                }
            });
        }
    });


});
