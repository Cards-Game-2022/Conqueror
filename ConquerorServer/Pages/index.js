 

document.getElementById("click").addEventListener("click", executeEffect)
document.getElementById("none").addEventListener("click", deleteEffect)

function executeEffect() { 
    value = document.getElementById("value")
    effect = document.getElementById("effect-enemy")
    message = document.getElementById("message-enemy")
    negation = document.getElementById("negation")
    text = document.getElementById("text")
    text.style.display = "block"
    negation.style.display = "block"
    effect.style.display = "block"
    //effect.src = value.value
    setTimeout(() => {
        effect.style.display = "none"
        message.style.display = "block"
        text.style.display = "none"
        setTimeout(() => {
            message.style.display = "none"
            negation.style.display = "none"
        }, 1000);
    }, 1000);
}

function deleteEffect() {

    effect = document.getElementById("effect-enemy")
    effect.style.display = "none"
}
 
