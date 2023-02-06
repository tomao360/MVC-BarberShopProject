function addBarber() {
    let divBarber = document.getElementById("addBarber");
    if (divBarber.style.display === "none") {
        divBarber.style.display = "";
    } else {
        divBarber.style.display = "none";
    }
}