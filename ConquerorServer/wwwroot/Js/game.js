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
function ExecuteEffect() { 
    effect = document.getElementById("effect-enemy")
    message = document.getElementById("message-enemy")
    effect.style.display = "block"
    setTimeout(() => {
        effect.style.display = "none"
        message.style.display = "block"
        setTimeout(() => {
            message.style.display = "none"
        }, 1000);
    }, 1000);
}

function HideNextMove() {
    document.getElementById("click").style.display = "none";
}