"use strict"; 
$(document).ready(function () {

    $('#city').prop('disabled', true);
    $("#searchWeather").click(function () {
        if (searchRunning || $("#country").val() === ""
            || $("#city").val() === null
            || $("#city").val() === "") {
            $("#retrieveWeather").html("Please select a city then search it.");
            $("#retrieveWeather").css("visibility", "");
            return;
        } 
        searchRunning = true;
        var city = $("#city").val().trim();
        getAJAX(city);
    });

    $('#clearinput').click(function () {
        clearInput();
        
    });
    $('#country').focusout(function () {
        if ($("#country").val() === "") return;
        if (searchRunning) return;
        searchRunning = true;
        GetCitiesByCountryName($("#country").val().trim(), "city");
    });
    $(window).keydown(function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            return false;
        }
    });
});
var searchRunning = false;

function clearInput() {
    //input bar
    $('#country').val("");
    //comboBox
    $("#city").val("");
    $('#city').prop('disabled', true);
    //empty table
    $('#Location').html("");
    $('#Time').html("");
    $('#Wind').html("");
    $('#Visibility').html("");
    $('#Conditions').html("");
    $('#Temperature').html("");
    $('#Humidity').html("");
    $('#Pressure').html("");

}
function GetCitiesByCountryName(countryName, comboBoxName, callbackfunction) {
    $("#retrieveCities").html("Loading a list of cities...");
    $("#retrieveCities").css("visibility", "");
    callbackfunction = callbackfunction || null;
    $('#city').prop('disabled', true);
    //send country name by user inputed to controller.
    $.ajax({
        type: "Get",
        url: siteRoot + "/Search/GetComboBoxDropDownList",
        dataType: "json",
        data: { countryName: countryName },
        success: function (data) {
            if (data.length > 0) {
                var select = $('#' + comboBoxName);
                var options;
                if (select.prop) {
                    options = select.prop('options');
                }
                else {
                    options = select.attr('options');
                }
                $('option', select).remove();

                $.each(data, function (index) {
                    options[options.length] = new Option(data[index].city, data[index].city);
                });
                options[options.length] = new Option("Please select", "");
                select.val('');
                $('#city').prop('disabled', false);
                $("#retrieveCities").css("visibility", "hidden");
            }
            else
            {
                $("#retrieveCities").html("No city data available for this country name");
            }
        },
        error: function (errMsg) {
            $("#retrieveCities").html("Api is not available at the moment");
            console.log(errMsg);
        }
    }).done(function () {      
        searchRunning = false;
        if (callbackfunction !== null) {
            callbackfunction();
        }
     });
}
//send seleted city to controller for requesting API
function getAJAX(city) {
    $("#retrieveWeather").html("Loading Weather from API...");
    $("#retrieveWeather").css("visibility", "");
    $.ajax({
        url: 'Search/GetWeatherAsync',
        type: 'GET',
        async: true,
        data: { city: city },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        error: function (jqXHR, textStatus, errorThrown) {
            $("#retrieveWeather").html("Api is not available at the moment");
            
        },
        success: function (result) {
            if (result.name !== "") {
                searchRunning = false;
                var Location = result.name;
                var temp = result.main.temp;
                var pressure = result.main.pressure;
                var humidity = result.main.humidity;
                var wind = result.wind.speed;
                var skycondition = result.weather[0].main;
                var time = getDate();
                var visibility = result.visibility;
                $('#Location').html(Location);
                $('#Time').html(time);
                $('#Wind').html(wind);
                $('#Visibility').html(visibility);
                $('#Conditions').html(skycondition);
                $('#Temperature').html(temp);
                $('#Humidity').html(humidity);
                $('#Pressure').html(pressure);
                $("#retrieveWeather").css("visibility", "hidden");
            }
            else
            {
                $("#retrieveWeather").html("No data available for this city");
            }
        }
    }).done(function () {
        searchRunning = false;
    });
}

function getDate()
{
    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var output = d.getFullYear() + '/' +
        (month < 10 ? '0' : '') + month + '/' +
        (day < 10 ? '0' : '') + day;
    return output;
}