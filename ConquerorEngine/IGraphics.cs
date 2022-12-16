using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conqueror.Logic;

    interface IGraphics {
        
        /// <summary>
        /// Metodo para que el juego pueda recibir la carta a activar
        /// </summary>
        /// <param name="card">La carta jugada</param>
        public void Input(Card card);
        
        /// <summary>
        /// Metodo para mostrar los cambios que ocurren en el juego en una interfaz
        /// </summary>
        public void Output();
    }
