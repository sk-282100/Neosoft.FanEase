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
            var description1 = "Please Watch Whole Video";
            var description2 = "Please Watch Whole Video";
            var desscription3 = "Please Watch Whole Video";
            for (i = 0; i < (videodata.length-2); i+=3) {
                if (videodata[i].decription != null) {
                    description1 = videodata[i].decription;
                }
                if (videodata[i+1].decription != null) {
                    description2 = videodata[i+1].decription;
                }
                if (videodata[i+2].decription != null) {
                    description3 = videodata[i+2].decription;
                }
                
            
                    $('#showTable').append
                        (`
                        <div class="row">
                           <div class="column">
                                <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i].videoId}">
                               <img class=" mt-4 ml-4 rounded-3" src="/Uploads/Creators/Videos/${videodata[i].videoImage}" style="height: 150px; width: 220px;" /><br>
                               <label value="${videodata[i].title}">${videodata[i].title}</label><br>
                                
                               <label type="text" placeholder="This is my video description" readonly>${videodata[i].decription}</label>
                                 </a>
                            </div>
                           
                            
                            <div class="column">
                               <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i + 1].videoId}">
                               <img class=" mt-4 ml-4 rounded-3" src="/Uploads/Creators/Videos/${videodata[i+1].videoImage}" style="height: 150px; width: 220px;" /><br>
                               <label placeholder="Diwali Ads" />${videodata[i + 1].title}</label><br>
                               <label type="text" placeholder="This is my video description" readonly>${videodata[i + 1].decription}</label>
                                </a>
                            </div>
                         
                            
                            <div class="column">
                                <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i + 2].videoId}">
                               <img class=" mt-4 ml-4 rounded-3" src="/Uploads/Creators/Videos/${videodata[i+2].videoImage}" style="height: 150px; width: 220px;" /><br>
                               <label value="${videodata[i + 2].title}" placeholder="Diwali Ads" style="text-align:center;">${videodata[i + 2].title}</label><br>
                               <label type="text" placeholder="This is my video description" readonly>${videodata[i + 2].decription}</label><br>
                                </a>
                            </div>
                           
                        </div>

                `);
                }

        }
    });

    $('#selectVideo').change(function () {
        if ($('#selectVideo').val() == 2) {
            $.ajax({
                type: 'GET',
                url: "/Viewer/GetVideos",
                async: false,
                contentType: 'application/json',
                success: function (data) {
                    videodata = data;
                    var description1 = "Please Watch Whole Video";
                    var description2 = "Please Watch Whole Video";
                    var desscription3 = "Please Watch Whole Video";
                    $('#showTable').empty();
                    for (var i = (videodata.length-2); i > 0; i -= 3) {
                        var temp = videodata[i].decription;
                        if (videodata[i].decription == null) {
                            description1 = videodata[i].decription;
                        }
                        if (videodata[i - 1].decription == null) {
                            description2 = videodata[i - 1].decription;
                        }
                        if (videodata[i - 2].decription == null) {
                            description3 = videodata[i - 2].decription;
                        }


                        
                        $('#showTable').append
                            (`
                        <div class="row">
                           <div class="column">
                                <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i].videoId}">
                               <img class=" mt-4 ml-4 rounded-3" src="/Uploads/Creators/Videos/${videodata[i].videoImage}" style="height: 150px; width: 220px;" /><br>
                               <label value="${videodata[i].title}">${videodata[i].title}</label><br>
                                
                               <label type="text" placeholder="This is my video description" readonly>${videodata[i].decription}</label>
                                 </a>
                            </div>
                           
                            
                            <div class="column">
                               <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i - 1].videoId}">
                               <img class=" mt-4 ml-4 rounded-3" src="/Uploads/Creators/Videos/${videodata[i - 1].videoImage}" style="height: 150px; width: 220px;" /><br>
                               <label placeholder="Diwali Ads" />${videodata[i - 1].title}</label><br>
                               <label type="text" placeholder="This is my video description" readonly>${videodata[i - 1].decription}</label>
                                </a>
                            </div>
                         
                            
                            <div class="column">
                                <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i - 2].videoId}">
                               <img class=" mt-4 ml-4 rounded-3" src="/Uploads/Creators/Videos/${videodata[i - 2].videoImage}" style="height: 150px; width: 220px;" /><br>
                               <label value="${videodata[i - 2].title}" placeholder="Diwali Ads" style="text-align:center;">${videodata[i - 2].title}</label><br>
                               <label type="text" placeholder="This is my video description" readonly>${videodata[i - 2].decription}</label><br>
                                </a>
                            </div>

                        </div>
                `);
                    }

                }
            });
        }
    });

});
