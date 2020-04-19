function getModelForCurrentMake() {
    var makeId = $("#makeList").val();
    var url = "/api/data/getModels";

    $.getJSON(url, { makeId: makeId }, function (data) {
        var item = "";
        $("#modelId").empty();
        $.each(data, function (i, model) {
            item += '<option value="' + model.value + '">' + model.text + '</option>'
        });
        $("#modelId").html(item);
    });
}

//$("#makeList").change(
//    function () {
//    var makeId = $("#makeList").val();
//    var url = "/api/data/getModels";

//    $.getJSON(url, { makeId: makeId }, function (data) {
//        var item = "";
//        $("#modelId").empty();
//        $.each(data, function (i, model) {
//            item += '<option value="' + model.value + '">' + model.text + '</option>'
//        });
//        $("#modelId").html(item);
//    });
//});

function getDrivesForCurrentFuel() {
    var fuelId = $("#fuelList").val();
    var modelId = $("#modelId").val();
    var url = "/api/data/getDrives";

    $.getJSON(url, { modelId: modelId, fuelId: fuelId }, function (data) {
        var item = "";
        $("#driveId").empty();
        $.each(data, function (i, drive) {
            item += '<option value="' + drive.value + '">' + drive.text + '</option>'
        });
        $("#driveId").html(item);
    });
}
//$("#fuelList").change(function () {
//    var fuelId = $("#fuelList").val();
//    var modelId = $("#modelId").val();
//    var url = "/api/data/getDrives";

//    $.getJSON(url, { modelId: modelId, fuelId: fuelId }, function (data) {
//        var item = "";
//        $("#driveId").empty();
//        $.each(data, function (i, drive) {
//            item += '<option value="' + drive.value + '">' + drive.text + '</option>'
//        });
//        $("#driveId").html(item);
//    });
//});

function showMakeInput() {
    var makes = document.getElementById("makeList")
    makes.addEventListener("change", function myfunction() {
        var makeDiv = document.getElementById("makeName");
        var makeinput = document.getElementById("makeNameinput");

        if (makes.value === "999999999") {
            makeinput.value = "";
            makeDiv.hidden = false;
            //x.style.display = "none";
        } else {
            makeDiv.hidden = true;
            makeinput.value = makes.value;
            //x.style.display = "block";
        }
    });
}
