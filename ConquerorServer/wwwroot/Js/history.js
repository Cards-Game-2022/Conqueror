function StartHistory() {

    player = document.getElementById("audio-player");
    player.play();
    document.getElementById("ver-historia").style.display = "none";
    
    text = "En una antigua era, el mundo estaba devastado por la guerra contra el Rey Demonio. Muchos heroes fallecieron en la lucha, sus nombres seran recordados por la eternidad. Pero la lucha todavia no ha acabado y aqui es donde entras tu, joven Heroe. Es tu momento de levantarte y emprender tu viaje para derrotar el Rey Demonio. Mucha suerte..."
    pos = 0

    time = () => {
        setTimeout(() =>  {
            id = document.getElementById("text");
            id.innerHTML = id.innerHTML + text[pos]
            pos++ 
            if (pos == text.length) {
                player.pause();
                window.location.href = window.location.toString().replace("History", "gameEnvironment"); 
                return
            }
            time()
            
        }, 50)
    }
time()
}