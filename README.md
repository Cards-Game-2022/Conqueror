# Conqueror

+ **Inicio del juego**:
  
  Para iniciar el juego, deberás acceder a la carpeta contenedora del mismo llamada Conqueror. Una vez allí, abres la carpeta en un terminal y ejectuas
  
  ```bash
  dotnet run --project ConquerorServer
  ```

  Si usas linux, puedes ejecutar
  ```bash
  make dev
  ```

+ **Elementos del juego**:

  + Los jugadores tienen vida, que iniciará en 30.
  + Los jugadores tienen charms, que iniciarán en 5.
  + Los jugadores tienen un deck y un conjunto de cartas en la mano.
  + Cada jugador obtiene las cartas en su mano a partir de las cartas de su deck.
  + Los charms representan el coste que tiene una carta para ser jugada. Mientras más util sea la carta, mayor será su coste en charms.
  + Los jugadores pueden tener, en un momento dado del juego, un valor negativo de charms pues esto indica que tienen que esperar a obtener más charms para activar una carta, o que pueden activar aquellas cuyo coste sea 0.
  + Los jugadores pueden no tener cartas en su mano ni en su deck. Esto solo significa que no podrán activar efectos, pero no necesariamente han perdido la partida.

+ **Reglas**:

  + En cada turno el jugador solo puede jugar una carta.
  + Cada turno el jugador recibe un charm.  
  + Cada turno el jugador recibe una carta.
  + Las cartas existentes actúan sobre los elementos de un jugador como los charms y la vida.
  + El juego termina únicamente cuando la vida de alguno de los jugadores llegue a cero.

+ **Forma de jugar**:

  + Para activar una carta solo debes hacer clic sobre ella.
  + Si no deseas activar ninguna carta o no puedes, debes activar el botón de Finalizar Turno para continuar con el juego.
  + Si deseas rendirte y terminar la partida, puedes tocar el botón Rendirse y automáticamente perderás el juego.
  + Una vez finalice una partida, puedes elegir entre jugar nuevamente o volver al menú principal.

+ **Modos de juego**:

  *Existen tres modos de juego fundamentales:*
  1. Torneo: Comienzas una partida contra un jugador virtual.

  2. Partida rápida: Comienzas una partida entre dos jugadores humanos.
  
  3. Jugadores virtuales: Comienzas una partida donde juegan los jugadores virtuales entre ellos y tú serás un espectador con la perspectiva de uno de los jugadores virtuales.
  