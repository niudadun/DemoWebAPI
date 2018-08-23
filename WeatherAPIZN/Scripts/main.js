"use strict"; 
$(document).ready(function () {

    $('#table').bootstrapTable();
    $('#city').prop('disabled', true);
    $("#searchWeather").click(function () {
        if (searchRunning) return;
        searchRunning = true;
        var city = $("#city").val();
        $("#table").bootstrapTable('resetSearch');
        getAJAX(city);
    });

    $('#clearinput').click(function () {
        clearInput();
        
    });
    $('#country').focusout(function () {
        if ($("#country").val() === "") return;
        GetCitiesByCountryName($("#country").val(), "city");
    })
});
var searchRunning = false;

function clearInput() {
    //input bar
    $('#country').val("");
    //comboBox
    $("#city").val("");
    //empty table
    $('#table').bootstrapTable('removeAll');
    $('#city').prop('disabled', true);

}
function GetCitiesByCountryName(countryName, comboBoxName, callbackfunction) {
    $("#retrieveCities").css("visibility", "");
    callbackfunction = callbackfunction || null;
    $('#city').prop('disabled', true);
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
            }
        },
        error: function (errMsg) {
            console.log(errMsg);
        }
    }).done(function () {
       
        $("#retrieveCities").css("visibility", "hidden");
        if (callbackfunction !== null) {
            callbackfunction();
        }
    });
}
function getAJAX(city) {
    $("#retrieveWeather").css("visibility", "");
    $.ajax({
        url: 'Search/GetWeatherAsync',
        type: 'GET',
        async: true,
        data: { city: city },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        error: function (jqXHR, textStatus, errorThrown) {
            $('#table').bootstrapTable('removeAll');
            searchRunning = false;
        },
        success: function (result) {
            if (result.name !== "")
            {
                searchRunning = false;
                var dataPairs = [];
                var Location = result.name;
                var temp = result.main.temp;
                var pressure = result.main.pressure;
                var humidity = result.main.humidity;
                var wind = result.wind.speed;
                var skycondition = result.weather[0].main;
                var time = getDate();
                var visibility = result.visibility;
                dataPairs.push({
                    Location: Location,
                    Time: time,
                    Wind: wind,
                    Visibility: visibility,
                    Conditions: skycondition,
                    Temperature: temp,
                    Humidity: humidity,
                    Pressure: pressure
                });
                $('#table').bootstrapTable('removeAll');
                $('#table').bootstrapTable('load', dataPairs);
            }
            
        }
    }).done(function () {
        $("#retrieveWeather").css("visibility", "hidden")
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
    return output
}