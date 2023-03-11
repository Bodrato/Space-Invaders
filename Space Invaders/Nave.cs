using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Nave : Sprite
    {
        public Nave() 
        {
            MoverA(59, 26);
        }

        public Nave(int x, int y)
        {
            this.x = x;
            this.y = y;
            Imagen = "X";
        }

        public void MoverDerecha()
        {
            if(x == 119)
            {
                Borrar();
                x = 119;
                Dibujar();
            }
            else { Borrar(); x++; Dibujar(); }
        }   

        public void MoverIzquierda()
        {
            if(x == 1)
            {
                Borrar();
                x = 1;
                Dibujar();
            }
            else { Borrar(); x--; Dibujar(); }
        }

        public override void Dibujar()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.Write("X");
        }
    }
}
