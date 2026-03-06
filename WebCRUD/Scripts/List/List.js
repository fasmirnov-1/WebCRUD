var isTabOpened;

function LoadRecords() {
    var jsonMaterials = null;

    $.ajax({
        url: "https://localhost:44370/api/Material/GetAllMaterials",
        type: "get",
        success: function (data) {
            jsonMaterials == data;
        },
        error: function (Message) {
            alert(Message);
            return null;
        }
    });

    if (jsonMaterials == null) {
        return null;
    }

    var materials = JSON.parse(jsonMaterials);
    return materials;
}

function GetWidthPx(percent) {
    return percent * window.innerWidth / 100;
}

function OpenWindow() {
    console.log(isTabOpened);

    if (isTabOpened == true) {
        return;
    }

    isTabOpened = true;
    var wnd = window.open('List/AddForm', '_blank', 'left=100,top=100,width=' + GetWidthPx(70) + ',height=300,toolbar=1,resizable=0');

    console.log(wnd.closed);

    var interval = setInterval(function () {
        if (wnd.closed == true) {
            isTabOpened = false;
            clearInterval(interval);
        }
    }, 1000)
}