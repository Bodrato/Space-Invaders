using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Sprite
    {
        public bool Activo { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string Imagen { get; set; }

        public void MoverA(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual void Dibujar()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Imagen);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Borrar()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("   ");
        }

        public virtual bool ColisionaCon(Sprite sprite)
        {
            if((this.x == sprite.x && this.y == sprite.y) || (this.x+1 == sprite.x && this.y+1 == sprite.y)) { return true; }
            else { return false; }
        }
    }
}
