var Id = 0;
function changeId(id) {
    Id = id;
}
function insertValue(elem) {

    var isChecked = $(`#campaignRadioBtn_${Id}`).is(':checked');
    if (isChecked) {
        var campaignId = Id;
        $.ajax({
            type: 'GET',
            url: '/Creator/AddExistingCampaignId/' + campaignId,
            async: false,
            contentType: 'application/json',
            success: function (data) {

            },
            error: function (error) {

            }
        });
    }
    else {
        alert("Please Select Campaign from the list given below");
    }

    
}