var Id = 0;
function changeId(id) {
    Id = id;
}
function insertValue(elem) {

    var isChecked = $(`#campaignRadioBtn_${Id}`).is(':checked');
    if (isChecked) {
        var campaignId = Id;
        window.location = '/Creator/AddExistingCampaignId/' + campaignId;
       
    }
    else {
        alert("Please Select Campaign from the list given below");
    }

    
}