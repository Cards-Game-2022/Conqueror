## Resumen: 

- Cambie todo lo que tu tio habia recomendado dentro de las clases
- Implemente un nuevo metodo Draw dentro de Deck que recibe, a diferencia del Draw normal, la carta especifica que se quiere robar. Eso lo hice para poder activar ciertos efectos que se me ocurrieron. Si la carta no aparece, muestra un error y retorna null.
- Dentro del deck todavia no he hecho cambios. Lo que quiero es que cada jugador tenga su deck y puedan hacer las mismas acciones que hacian antes sin afectar nada del funcionamiento del juego hasta ahora. Esto no lo he cambiado. Solo cree la propiedad PlayerDeck dentro de Player
- Cambie los nombres de las funciones que hacen llamados dentro de los razor para que estuviera mas limpio eso.
- Hice lo del metodo que comprueba si hay algun ganador y si es asi muestra el cartelito que tiene los dos botones de recargar y empezar un nuevo juego o de ir al menu principal. Ya eso pincha lo que esta bien feo. Despues lo acomodo
- Hice un <div> para que muestre cuando no hay cartas en la mano porque antes se quedaba roto.
- La IA solo activa una carta cuando se toca fin del turno. Esto provoca que, por ahora, mientras el jugador tenga charms y cartas puede seguir haciendole daño al enemigo, pero eso lo quiero arreglar.

  **En cuanto a codigo realmente no hice muchos cambios significativos que le agregaran funcionalidades al juego. Estuvo entendiendo como fucnionaban varias cosas y lo que mas trabajo me costo de ver fue que la IA se llamaba sola cada vez que se tocaba una carta.**

Cosas que quiero hacer:
- Verificar que cada vez que se toque una carta, los charms que tienes te permitan jugarla.
- Mostrar mensajes de error siempre que el jugador quiera hacer algo que no se puede.
- Poner informacion sobre la carta que jugo el contrario y un tiempo de espera para cuando juegue la IA.
- Hacer una IA que ataque siempre con la carta que quite mas puntos de vida
- Hacer las funciones en el lenguaje.
- Editar el cartel del ganador.
- Guardar las fotos que seleccione el usuario para las cartas en una carpeta y obtener su path.
- Agregar gifs para los efectos de daños y otros.
- Cambiar donde sale la IA en torneo y en partida rapida poner PVP.
- Arreglar todo lo de PVP
- Modal a las cartas que parezcan cartas
- Clip-path

- Editar la interfaz grafica en la creacion de cartas.
- Vincular la interfaz de creacion de cartas con el juego
- Arreglar modo torneo.
- Cartas de modificacion de estados
- Manejar las IA en una lista.
- Copiar los estados para que las IA trabajen con el.
- Estados IEnumerable.
- Agregar estados al juego. Estados de las cartas o estados de los jugadores (o ambos).


Dudas:
- Rareza de las cartas.
- JSON.
- Estados de cartas(opcional).
- Azure.
- Seguridad de la aplicacion.
- Uso de interfaces, clases abstractas...
- IA random, max ataque... ?
- Static classes. Static propierties