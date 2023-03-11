using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Enemigo2 : Enemigo
    {
        public Enemigo2(int x, int y)
        {
            this.x = x;
            this.y = y;
            Imagen = "HH";
            Activo = true;
        }

        public override void Dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.Write(Imagen);
        }
    }
}
