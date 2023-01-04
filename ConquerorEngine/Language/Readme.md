Objetivo:
- Modificar valores del estado del juego con el fin de modificar el estado del juego.

Caracteristicas:
- al final de toda linea debe ir un ;
- los bloques de codigo deben empezar por { y finalizar en } y todos los bloques excepto el ultimo de terminar en };
- no hay tipado de varibles el unico tipo que existe es int y en las estructuras con condicion se trabaja internamente con un tipo bool
- existen funciones predefinidas y variables constantes predefinidas
- no existen comentarios

Sintaxis:
- operaciones algebraicas: +   - /  *  ( )
- operaciones boleanas: | &  <  >  ==
- asignacion: =
- estructuras condicionales: if(condicion){}
- estucturas iterativas: while(condicion){}
- uso de funciones predefinidas: fs()
- declaracion y uso de variables enteras
- dentro de las estructuras condicionales no se pueden poner parantesis

Ejemplos de codigo
```cs
    EnemyLife= 2; 
    a = 4;
    if (EnemyLife == 2 | MyLife > 2) {
        EnemyLife = a;
        ChangeHands();
    };
    while (EnemyLife > 1) {
        EnemyLife = EnemyLife - a;
    }
```