var videodata = 0;
$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: "/Viewer/GetVideos",
        async: false,
        contentType: 'application/json',
        success: function (data) {
            videodata = data;
            for (i = 0; i < videodata.length; i++) {
                var temp = videodata[0].videoId;
            //$.each(videodata,
            //    function (id, record) {
                    $('#showTable').append
                        (`
                   <table id="myTable" class="table table-sm table-hover">
                    <tbody>
                        <tr>
                            <td>
                                <a class="edit" href="/VideoViewer/VideoDisplay/${videodata[i].videoId}.ToString()">
                                        <div class="row m-4">
                                            <div class="col"><img class=" mt-4 ml-4 rounded-3" src="/Uploads/Creators/Videos/${videodata[i].videoImage}" style="height: 150px; width: 220px;" /></div>
                                            <div class="col mr-5 ">
                                                <div class="form-group">
                                                    <label class="font-weight-bold">Title</label>
                                                    <input class="form-control" type="text" value="${videodata[i].videoTitle}" placeholder="Diwali Ads" readonly />
                                                </div>
                                                <div class="form-group">
                                                    <label class="font-weight-bold">Description</label>
                                                    <textarea class="form-control" type="text" placeholder="This is my video description" readonly>${videodata[i].decription}</textarea>
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
