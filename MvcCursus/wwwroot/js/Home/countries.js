
function getCountries() {
    // Gebruik jQuery om de URL aan te roepen
    // Na het downloaden (asynchroon) wordt een callback functie aangeroepen

    // Check of de landen data al gecached is
    if (localStorage.Countries) {
        console.log("Countries from localStorage");
        showCountries(JSON.parse(localStorage.Countries));
    }
    else {
        console.log("Downloading countries...");
        $.getJSON("https://restcountries.eu/rest/v2", showCountries);
    }
}


// GET, PUT, POST, DELETE

// Postman tool voor testen van Web APIs



function showCountries(data) {
    localStorage.Countries = JSON.stringify(data);

    data.sort((x, y) => y.population - x.population);

    var html = "<table id='countriesTable'><thead><tr><td>Naam</td><td>Inwoners</td><td>Regio</td><td>Hoofdstad</td><td>Vlag</td></tr></thead>";

    for (var i = 0; i < data.length; i++) {
        // Voor de juiste property namen kijk in de browser naar de raw data van deze web api
        //console.log(data[i].name + " - " + data[i].capital);
        html += "<tr>";
        html += "<td>" + data[i].name + "</td>";
        html += "<td>" + data[i].population + "</td>";
        html += "<td>" + data[i].region + "</td>";
        html += "<td>" + data[i].capital + "</td>";
        html += "<td><img width='100px' src='" + data[i].flag + "' /></td>";
        html += "</tr>";
    }

    //console.log(data[0].name);
    //console.log(data[0].borders[0]);
    //console.log(data[0].borders[1]);

    html += "</table>";

    $("#output").html(html);
}