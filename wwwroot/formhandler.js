function postPlat() {
    fetch("localhost:5150/api/plats", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "RequestVerificationToken": window.requestVerificationToken
        },
        body: JSON.stringify({
            nomPlat: document.getElementById("nomPlat").value,
            saveurPlat: document.querySelector('input[name="saveurPlat"]:checked').value,
            estEpicePlat: document.getElementById("estEpice").checked,
            estHealthy: document.getElementById("estHealthy").checked,
            estVegetarien: document.getElementById("estVegetarien").checked,
            originePlat: document.getElementById("originePlat").value,
            tempsPreparationPlat: document.getElementById("tempsPreparationPlat").value,
            repasPlat: document.querySelector('input[name="repas"]:checked').value,
            lienRecettePlat: document.getElementById("lienRecettePlat").value,
            lienPhotoPlat: document.getElementById("lienPhotoPlat").value,
            notePlat: document.querySelector('input[name="notePlat"]:checked').value,
        })})
        .then((response) => response.json())
        .then((json) => console.log(json));
}

