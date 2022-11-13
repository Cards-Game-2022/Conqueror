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
    window.location.reload();
} 
 /*
function toWinner(winner) {
   // alert("El ganador es: " + winner);

    location.href = "/winner?win=" + document.getElementsByName("winner").values;
}

*/
