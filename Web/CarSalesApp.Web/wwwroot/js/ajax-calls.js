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

function getDrivesWithCurrentFuelForAdCar() {
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

function showMakeInput() {
    var makes = document.getElementById("makeList")
    var makeDiv = document.getElementById("makeName");
    var makeinput = document.getElementById("makeNameinput");

    if (makes.value === "999999999") {
            
        makeDiv.hidden = false;
        makeinput.value = "";
        //x.style.display = "none";
    } else {
        makeinput.value = makes.value;
        makeDiv.hidden = true;
            
        //x.style.display = "block";
    }
    
}

function showFeatureTypeInput() {
    var types = document.getElementById("types")
    var typeDiv = document.getElementById("divType");
    var typeInput = document.getElementById("typeInput");

    if (types.value === "999999999") {
        typeInput.value = "";
        typeDiv.hidden = false;
        //x.style.display = "none";
    } else {
        typeDiv.hidden = true;
        typeInput.value = types.value;
        //x.style.display = "block";
    }
}

function getModelForCurrentMakeInDetails() {
    var makeId = $("#makeList").val();
    var url = "/api/data/getModels";

    $.getJSON(url, { makeId: makeId }, function (data) {
        var item = "";
        $("#modelId").empty();
        $.each(data, function (i, model) {
            //<li>Gadgets</li>
            //<input asp-for="Model" class="form-control" placeholder="Enter Model" />
            item += '<li style="color:;font-size:17.5px" value="' + model.value + '"><a href="/Administration/Makes/Edit/' + model.value + '">' + model.text + '</a></li>'
            //item += '<input class="form-control" value="' + model.text + '"disabled /> <br />'
        });
        $("#modelId").html(item);
    });
}
