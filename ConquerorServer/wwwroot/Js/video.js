function presionar() { 
    if (!medio.paused && !medio.ended) { 
        medio.pause(); 
        reproducir.src="img/play_0.png" // con esto cambia el texto de reproducir
        window.clearInterval(bucle); 
    } else { 
        medio.play(); 
        reproducir.src="img/pause.png"
        bucle=setInterval(estado, 100); 
    } 
}
function estado() { 
    if (!medio.ended){ 
        var total=parseInt(medio.currentTime*maximo/medio.duration); 
        progreso.style.width=total+'px'; 
        
    } else { 
        progreso.style.width='0px'; 
        reproducir.src="img/play_blue.png"
        window.clearInterval(bucle); 
    } 
}
function mover(e) { 
    var ratonX=e.pageX-barra.offsetLeft;  // offsetLeft es la distancia desde el lado izq de la pagina a el elemento ya que 
                                            // pageX devuelve la posicion relativa a toda la pagina no al elemento
    var nuevoTiempo=ratonX*medio.duration/maximo; 
    medio.currentTime=nuevoTiempo; 
    progreso.style.width=ratonX+'px'; 
}
function iniciar() {      
    medio = document.getElementById("medio")
    medio.play();

    document.getElementById("click-to-play").style.display = "none";
}
window.addEventListener('load',iniciar);

function Finished() {
    skip = document.getElementById("skipButton");
    skip.style.display = "grid";
    
    setTimeout(() => {
        skip.style.display = "none"
    }, 50000)

    setTimeout(() => {
        GoToMenu = document.getElementById("GoToMenu");
        GoToMenu.style.display = "grid"
    }, 50100)
}
