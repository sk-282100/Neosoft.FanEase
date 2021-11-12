var advertisementArray = [];

function changeTxt(elem)
{
        var id = $(elem).attr("id");
        if (id == "btn1")
        {
            $('#btn2').text("Select").removeClass('btn-primary').addClass('btn-outline-primary');
            $(elem).text("Selected").removeClass('btn-outline-primary').addClass('btn-primary');
            $('#img1').css("border", "3px solid skyblue");
            $('#img2').css("border", "1px solid grey");
            $('#sectionDiv').empty();
            for (var i = 0; i < 5; i++)
            {
                $('#sectionDiv').append
                (`
                    <h3 class="text-center ">Section ${i + 1}</h3>
                        <div class="row m-4 border border-dark">
                            <div class="col">
                                <img id="addImg${i}" class=" mt-4 ml-4 rounded-3"  src="/Uploads/Creators/Images/06479d63-0677-47e8-8d60-0fbd033b7874_img2.jpg"  style="height: 150px; width: 220px;" />
                                 <video id="videoTag${i}" class=" mt-4 ml-4 rounded-3"  style="height: 150px; width: 220px;display: none;" controls>
                                        <source type="video/mp4"/>
                                </video>
                            </div>
                            <div class="col mr-5 ">
                                <div class="form-group">
                                    <label class="font-weight-bold">Title</label>
                                     <select id="selectId${i}" onchange="loadAllValues(this,${i})" class="form-control titleDropDown">
                                        <option value="0">Please Select Title</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label class="font-weight-bold">Description</label>
                                    <textarea  id="textAreadId${i}" class="form-control" type="text" placeholder="This is my video description" ></textarea>
                                </div>
                            </div>
                        </div>
                `);
            }
            loadValues();
        }
        else if (id == "btn2")
        {
            $('#btn1').text("Select").removeClass('btn-primary').addClass('btn-outline-primary');
            $(elem).text("Selected").removeClass('btn-outline-primary').addClass('btn-primary');
            $('#img2').css("border", "3px solid skyblue");
            $('#img1').css("border", "1px solid grey");
            $('#sectionDiv').empty();
            for (var i = 0; i < 3; i++) {
                $('#sectionDiv').append
                (`
                    <h3 class="text-center ">Section ${i + 1}</h3>
                        <div class="row m-4 border border-dark">
                            <div class="col">
                                <img id="addImg${i}" class=" mt-4 ml-4 rounded-3"  src="/Uploads/Creators/Images/06479d63-0677-47e8-8d60-0fbd033b7874_img2.jpg"  style="height: 150px; width: 220px;" />
                                 <video id="videoTag${i}" class=" mt-4 ml-4 rounded-3"  style="height: 150px; width: 220px;display: none;" controls>
                                        <source type="video/mp4"/>
                                </video>
                            </div>
                            <div class="col mr-5 ">
                                <div class="form-group">
                                    <label class="font-weight-bold">Title</label>
                                     <select id="selectId${i}" onchange="loadAllValues(this,${i})" class="form-control titleDropDown">
                                        <option value="0">Please Select Title</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label class="font-weight-bold">Description</label>
                                    <textarea  id="textAreadId${i}" class="form-control" type="text" placeholder="This is my video description" ></textarea>
                                </div>
                            </div>
                        </div>
                `);
            }
            loadValues();
        }
} 

function loadAllValues(elem, i) {
    var e = document.getElementById(`selectId${i}`);
    var title = e.options[e.selectedIndex].text;
    for (var j = 0; j < advertisementArray.length; j++)
    {
        if (advertisementArray[i].title === title) {
            $(`#textAreadId${i}`).text(advertisementArray[i].description);
            if (advertisementArray[i].imagePath != null) {
                document.getElementById(`addImg${i}`).style.display = "inline";
                $(`#addImg${i}`).attr("src", "/Uploads/Creators/Videos/" + advertisementArray[i].imagePath);
                document.getElementById(`videoTag${i}`).style.display = "none";
            }
            else {
                document.getElementById(`addImg${i}`).style.display = "none";
                document.getElementById(`videoTag${i}`).style.display = "inline";
                $(`#videoTag${i}`).attr("src", "/Uploads/Creators/Videos/" + advertisementArray[i].videoPath);
            }
            break;
        }
    }
}


function loadValues()
{
    $.ajax({
        type: 'GET',
        url: '/Creator/GetAdvertisement',
        async: false,
        contentType: 'application/json',
        success: function (data) {
            advertisementArray = data;
            console.log(data);
            $.each(data,
                function (id, text) {
                    $('.titleDropDown').append(
                        $('<option></option>').val(text.advertisementId).html(text.title)
                    );
                });
        }
    });

    $()
}

$(document).ready(function () {

});