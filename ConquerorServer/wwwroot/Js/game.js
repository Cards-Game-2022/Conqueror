function WinnerMessage() {
    text = document.getElementById("show-winner");    
    text.style.display = "grid"
}

function RefreshPage() {
    window.location = window.location.href+'?eraseCache=true';
}

function ErrorMessage() {
    error = document.getElementById("error-message");
    error.style.display = "grid";
    
    setTimeout(() => {
        error.style.display = "none"
    }, 1500)
}

document.getElementById("click").addEventListener("click", executeEffect)
document.getElementById("none").addEventListener("click", deleteEffect)

function executeEffect() { 
    value = document.getElementById("value")
    effect = document.getElementById("effect-enemy")
    effect.style.display = "block"
    //effect.src = value.value
}

function deleteEffect() {

    effect = document.getElementById("effect-enemy")
    effect.style.display = "none"
}
