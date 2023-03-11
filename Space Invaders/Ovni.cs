using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Ovni : Enemigo
    {
        public Ovni()
        {
            this.x = 0;
            this.y = 2;
            Imagen = "¶¶";
            Activo = true;
        }

        public override void Dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(x, y);
            Console.Write(Imagen);
        }

        public void Desaparecer()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.WriteLine("   ");
            Activo = false;
        }

        public void Mover()
        {
            if (Activo)
            {
                if (x < 117) { Borrar(); x++; Dibujar(); }
                else { Desaparecer(); }
            }
            else
            {
                Random random = new Random();
                int n = random.Next(0,100);
                if(n == 5)
                {
                    x = 0;
                    Activo = true;
                }
            }
        }
    }
}
