using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Enemigo : Sprite
    {
        public Enemigo()
        {
            MoverA(100, 80);
        }
        
        public Enemigo(int x, int y)
        {
             this.x = x;
             this.y = y;
            Imagen = "}{";
            Activo = true;
        }

        public override void Dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            Console.Write(Imagen);
        }
    }   
}
