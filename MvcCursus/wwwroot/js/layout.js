// Alles binnen het script element is Javascript
// JS is niet strongly typed maar weakly typed

var getal = 10;
var naam = "Xander";

console.log(getal);
console.log(naam);



function ShowTime() {
    // Hoe schrijf ik de tijd naar het scherm

    var tijd = new Date().toString().substring(15, 24);
    //document.getElementById("tijdstip").innerHTML = tijd;

    // In jQuery selecteer je een HTML element met een CSS-selector
    // De afkorting voor jQuery is de dollar $
    // In jQuery gebruik je de html functie om de innerHTML te setten
    $("#tijdstip").html(tijd);
}

