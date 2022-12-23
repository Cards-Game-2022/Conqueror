
function iniciar() {      
    medio = document.getElementById("medio")
    medio.play();

    document.getElementById("click-to-play").style.display = "none";
}
function Finished() {
    skip = document.getElementById("skipButton");
    skip.style.display = "flex";
    
    setTimeout(() => {
        skip.style.display = "none"
    }, 50000)

    setTimeout(() => {
        GoToMenu = document.getElementById("GoToMenu");
        GoToMenu.style.display = "flex"
    }, 50100)
}
