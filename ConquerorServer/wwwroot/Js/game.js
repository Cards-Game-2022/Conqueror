function WinnerMessage(){
    text = document.getElementById("text");    
    text.style.display = "inline"
    
    /*setTimeout(() => {
        console.log(text)
        text.style.display = "none"
    }, 1000)
    */
}

function refreshPage(){
    window.location = window.location.href+'?eraseCache=true';
    //window.location.reload(true);
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
 