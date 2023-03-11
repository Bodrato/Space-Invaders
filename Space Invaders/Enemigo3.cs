using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Enemigo3 : Enemigo
    {
        public Enemigo3(int x, int y)
        {
            this.x = x;
            this.y = y;
            Imagen = "XX";
            Activo = true;
        }

        public override void Dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(x, y);
            Console.Write(Imagen);
        }
    }
}
