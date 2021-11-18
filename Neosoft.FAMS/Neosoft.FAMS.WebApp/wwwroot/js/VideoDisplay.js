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
            for (i = 0; i < videodata.length; i++) {
                if (videodata[i].decription == null) {
                    Description = "Please Watch Video Completely.";
                }
                else {
                    Description = videodata[i].decription;
                }
                var temp = videodata[i].videoId;
            
                    $('#showTable').append
                        (`
                   <table id="myTable" class="table table-sm table-hover">
                    <tbody>
                        <tr>
                            <td>
                                <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i].videoId}">
                                        <div class="row m-4">
                                            <div class="col"><img class=" mt-4 ml-4 rounded-3" src="/Uploads/Creators/Videos/${videodata[i].videoImage}" style="height: 150px; width: 220px;" /></div>
                                            <div class="col mr-5 ">
                                                <div class="form-group">
                                                    <label class="font-weight-bold">Title</label>
                                                    <input class="form-control" type="text" value="${videodata[i].title}" placeholder="Diwali Ads" readonly />
                                                </div>
                                                <div class="form-group">
                                                    <label class="font-weight-bold">Description</label>
                                                    <textarea class="form-control" type="text" placeholder="This is my video description" readonly>${Description}</textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </td>
                            </tr>
                    </tbody>
                    </table>
                `);
                }

        }
    });
});
