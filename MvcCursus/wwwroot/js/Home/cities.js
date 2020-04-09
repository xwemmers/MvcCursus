
function getCities() {
    $.getJSON("https://www.xanderwemmers.nl/api/cities", showCities);

    setInterval(5000, getCities);
}

function postCity() {

    // dit wordt het nieuwe record
    var city = {
        CityName: $("#txtCityName").val(),
        Population: $("#txtPopulation").val(),
        Country: $("#txtCountry").val(),
        Year: $("#txtYear").val()
    };

    // POST is het uploaden van een nieuw record (city) naar de Web API
    $.post("https://www.xanderwemmers.nl/api/cities", city, getCities).fail(logError);
}

function logError(msg) {
    alert("Error!");
}

function deleteCity(id) {
    $.ajax({
        url: "https://www.xanderwemmers.nl/api/cities/" + id,
        method: "DELETE",
        success: getCities
    });
}

// GET, PUT, POST, DELETE


function showCities(data) {
    data.sort((x, y) => y.CityID - x.CityID);

    var html = "<table><thead><tr><td>ID</td><td>Naam</td><td>Land</td><td>Inwoners</td><td>Jaar</td></tr></thead>";

    for (var i = 0; i < data.length; i++) {
        html += "<tr>";
        html += "<td>" + data[i].CityID + "</td>";
        html += "<td>" + data[i].CityName + "</td>";
        html += "<td>" + data[i].Country + "</td>";
        html += "<td>" + data[i].Population + "</td>";
        html += "<td>" + data[i].Year + "</td>";
        html += "<td><a href='javascript:void(0);' onclick='deleteCity(" + data[i].CityID + ")'>delete</a></td>";
        
        html += "</tr>";
    }

    html += "</table>";

    $("#output").html(html);
}