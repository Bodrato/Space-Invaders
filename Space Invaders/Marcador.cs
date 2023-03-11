using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Marcador
    {
        public int Puntuacion { get; set; }
        public int Vidas { get; set; }

        public Marcador() { Puntuacion = 0; Vidas = 3; }
        public void Dibujar()
        {
            Console.SetCursorPosition(40, 0);
            Console.Write("Vidas {0}", Vidas);
            Console.SetCursorPosition(60,0);
            Console.Write("Puntuación {0}", Puntuacion);
        }
    }
}
