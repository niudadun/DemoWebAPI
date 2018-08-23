$(document).ready(function () {


    $("#search_Button").click(function () {
        //if (searchRunning) return;
        //searchRunning = true;
        var city = $("#cityName").val();
        //$(".weather").remove();
        getAJAX(city);
    });

});
var searchRunning = false;
function getAJAX(city) {

    $.ajax({
        url: 'Home/GetWeatherAsync',
        type: 'GET',
        async: true,
        data: { city: city },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        error: function (jqXHR, textStatus, errorThrown) {
            $("#result").html('API is - ' + errorThrown + "<br/>Please try it again.");
        },
        success: function (result) {
            var Location = result.name;
            var temp = result.main.temp;
            var pressure = result.main.pressure;
            var huminity = result.main.huminity;
            var wind = result.wind.speed;
            var skycondition = result.weather[0].main;
            var time = $.now();
            var visibility = result.visibility;
            $("#result").html("Location: " + Location + "<br/>"
                + "Time: " + time + "<br/>"
                + "Wind: " + wind + "<br/>"
                + "Visibility: " + visibility + "<br/>"
                + "Sky conditions: " + skycondition + "<br/>"
                + "Temperature: " + temp + "<br/>"
                + "Relative Huminity: " + huminity + "<br/>"
                + "Pressure: " + pressure + "<br/>"      
                 );
        }

    });
}