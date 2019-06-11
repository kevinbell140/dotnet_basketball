$(document).ready(function () {
    function updatePartial() {
        $.ajax({
            url: "/FantasyMatchups/GetRoster",
            type: "GET",
            data: {
                "matchId": $("#matchID").text(),
            },
            success: function (data) {
                $("#rosterPartial").html(data);
            },
            error: function (request, error) {
                alert("Error:" + JSON.stringify(error));
            }
        });
    }

    function updateScores() {
        $.ajax({
            url: "/FantasyMatchups/UpdateScores",
            type: "GET",
            data: {
                "matchID": $("#matchID").text(),
            },
            success: function (data) {
                if (data.homeScore > data.awayScore) {
                    $("#homeScore").addClass("matchup-header-winner");
                } else if (data.homeScore < data.awayScore) {
                    $("#awayScore").addClass("matchup-header-winner");
                }
                $("#homeScore").text(data.homeScore);
                $("#awayScore").text(data.awayScore);
            },
            error: function (request, error) {
                alert("Error:" + JSON.stringify(error));
            }
        })
    }
    updateScores();
    updatePartial();
    setInterval(updateScores, 4000)
    setInterval(updatePartial, 5000);
});