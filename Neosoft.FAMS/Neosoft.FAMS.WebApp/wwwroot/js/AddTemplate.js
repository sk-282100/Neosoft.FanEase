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
                                <img id="addImg${i}" class=" mt-4 ml-4 rounded-3"  src="/DefaultPhotos/default_template.png"  style="height: 150px; width: 220px;" />
                                 <video id="videoTag${i}" class=" mt-4 ml-4 rounded-3"  style="height: 150px; width: 220px;display: none;" controls>
                                        <source type="video/mp4"/>
                                </video>
                            </div>
                            <div class="col mr-5 ">
                                <div class="form-group">
                                    <label class="font-weight-bold">Title<sup style="color: red">*</sup><span id="error${i}" style="font-size:12px;" class="text-danger"></span></label>
                                     <select id="selectId${i}" onchange="loadAllValues(this,${i})" class="form-control titleDropDown">
                                        <option value="0">Please Select Title</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label class="font-weight-bold">Description</label>
                                    <textarea  id="textAreadId${i}" readonly class="form-control" type="text" placeholder="This is my video description" ></textarea>
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
                                <img id="addImg${i}" class=" mt-4 ml-4 rounded-3"  src="/DefaultPhotos/default_template.png"  style="height: 150px; width: 220px;" />
                                 <video id="videoTag${i}" class=" mt-4 ml-4 rounded-3"  style="height: 150px; width: 220px;display: none;" controls>
                                        <source type="video/mp4"/>
                                </video>
                            </div>
                            <div class="col mr-5 ">
                                <div class="form-group">
                                    <label class="font-weight-bold">Title<sup style="color: red">*</sup><span id="error${i}" style="font-size:12px;" class="text-danger"></span></label>
                                     <select id="selectId${i}" onchange="loadAllValues(this,${i})" class="form-control titleDropDown">
                                        <option value="0">Please Select Title</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label class="font-weight-bold">Description</label>
                                    <textarea  id="textAreadId${i}" readonly class="form-control" type="text" placeholder="This is my video description" ></textarea>
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
        if (advertisementArray[j].title === title) {
            $(`#textAreadId${i}`).text(advertisementArray[j].description);
            if (advertisementArray[j].imagePath != null) {
                document.getElementById(`addImg${i}`).style.display = "inline";
                $(`#addImg${i}`).attr("src", "/Uploads/Creators/Videos/" + advertisementArray[j].imagePath);
                document.getElementById(`videoTag${i}`).style.display = "none";
            }
            else {
                document.getElementById(`addImg${i}`).style.display = "none";
                document.getElementById(`videoTag${i}`).style.display = "inline";
                $(`#videoTag${i}`).attr("src", "/Uploads/Creators/Videos/" + advertisementArray[j].videoPath);
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
            $.each(data,
                function (id, text) {
                    $('.titleDropDown').append(
                        $('<option></option>').val(text.advertisementId).html(text.title)
                    );
                });
        }
    });

}

$(document).ready(function () {
    $('#templateProceed').click(function () {
        console.log("hhh");
        var count = $('#sectionDiv h3').length;
        if (count == 0)
            alert("First Please Select a Template");
        else
        {
            if (count == 3)
            {
                var errors = 0;
                for (var i = 0; i < 3; i++)
                {
                    if ($(`#selectId${i}`).val() == 0) {
                        $(`#error${i}`).text("Please select Title");
                        $(window).scrollTop(300 * i);
                        errors++;
                        break;
                    }
                    else
                        $(`#error${i}`).text("");
                }
                if (errors == 0)
                {
                    var section1 = $('#selectId0').val() + "-";
                    var section2 = $('#selectId1').val() + "-";
                    var section3 = $('#selectId2').val();

                    $.ajax({
                        url: "/Template/AddTemplateVideoData/" + section1 + section2 + section3,
                        type: 'POST',
                        success: function (result) {
                            window.location = '/Template/TemplateList';
                        },
                        error: function(result) {
                        }
                    });
                }

            }
            else
            {
                var errors = 0;
                for (var i = 0; i < 5; i++) {
                    if ($(`#selectId${i}`).val() == 0) {
                        $(`#error${i}`).text("Please select Title");
                        $(window).scrollTop(300 * i);
                        errors++;
                        break;
                    }
                    else
                        $(`#error${i}`).text("");
                }
                if(errors==0)
                {
                    var section1 = $('#selectId0').val() + "-";
                    var section2 = $('#selectId1').val() + "-";
                    var section3 = $('#selectId2').val() + "-";
                    var section4 = $('#selectId3').val() + "-";
                    var section5 = $('#selectId4').val();

                    $.ajax({
                        url: "/Template/AddTemplateVideoData/" + section1 + section2 + section3 + section4 + section5,
                        type: 'POST',
                        success: function (result) {
                            window.location = '/Template/TemplateList';
                        },
                        error: function (result) {
                        }
                    });
                }
            }
        }
    });
});