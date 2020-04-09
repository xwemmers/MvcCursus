// Dankzij de section PageScripts wordt dit stukje script alleen op deze pagina Create uitgevoerd

console.log("Dit is de Student Create pagina!");

function wisFormulier() {
    //document.getElementById("txtFirstname").value = "";
    //document.getElementById("txtLastname").value = "";
    //document.getElementById("txtDateOfBirth").value = "";

    // Dit gaan we straks korter schrijven in jQuery!
    // In 1 regel worden meerdere elementen geselecteerd en krijgen tegelijkertijd een waarde met de val() functie
    //$("input[type=text]").val("");

    $(".invoer").val("");

    //$("#txtLastname").val("");
    //$("#txtDateOfBirth").val("");
}

function saveLocal() {
    localStorage.Test = "Gelukt!";
    localStorage.Leeftijd = 46;

    localStorage.Firstname = document.getElementById("txtFirstname").value;
    localStorage.Lastname = document.getElementById("txtLastname").value;
    localStorage.DateOfBirth = document.getElementById("txtDateOfBirth").value;

    // Opslaan als een object? JSON = JavaScript Object Notation

    var st = {
        Firstname: document.getElementById("txtFirstname").value,
        Lastname: document.getElementById("txtLastname").value,
        DateOfBirth: document.getElementById("txtDateOfBirth").value
    };

    console.log(st);
    localStorage.Student = JSON.stringify(st);
}


// En de volgende functie lijkt daar erg op:

function loadLocal() {

    if (localStorage.Student) {
        // Parse de JSON terug naar een echt object:
        var st = JSON.parse(localStorage.Student);

        document.getElementById("txtFirstname").value = st.Firstname;
        document.getElementById("txtLastname").value = st.Lastname;
        document.getElementById("txtDateOfBirth").value = st.DateOfBirth;
    }
}

