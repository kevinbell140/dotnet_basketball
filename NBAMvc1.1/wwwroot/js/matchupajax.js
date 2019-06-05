$(document).ready(function () {
    $.ajax({
        url: "/FantasyMatchups/RefreshViewModel",
        type: "GET",
        dataType: "json",
        data: {
            "id": $("#matchID").html(),
        },
        success: function (data) {
            alert(JSON.stringify(data));
        },
        error: function (request, error) {
            alert("Request:" + JSON.stringify(request));
        }

    });
});