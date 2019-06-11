$(document).ready(function () {
    function update() {
        $.ajax({
            url: "/FantasyMatchups/GetRoster",
            type: "GET",
            data: {
                "matchId": $("#matchID").text(),
            },
            success: function (data) {
                $("#rosterPartial").html(data);
                alert("Success!");
            },
            error: function (request, error) {
                alert("Error:" + JSON.stringify(error));
            }
        });
    }
    update();
    setInterval(update, 5000);
});