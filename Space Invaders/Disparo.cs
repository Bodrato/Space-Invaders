using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Disparo : Sprite
    {
        public Disparo() { }

        public void MoverBala()
        {
            if(this.y != 0) { this.y--; }
        }

        public void MoverBalaEnemigo()
        {
            if (this.y != 28) { this.y++; }
        }

        public void Lanzar(int x,int y, ref bool disparar)
        {
            if(disparar == true) { this.x = x; this.y = y;}
            
            if(this.y > 0)
            {
                Borrar();
                MoverBala();
                DibujarBala(ref disparar);
            }
            if(this.y != 0) { disparar = false; }            
        }

        public void LanzarEnemigo(int x, int y, ref bool disparar)
        {
            if (disparar == true) { this.x = x; this.y = y; }

            if (this.y < 28)
            {
                Borrar();
                MoverBalaEnemigo();
                DibujarBalaEnemigo(ref disparar);
            }
            if (this.y != 28) { disparar = false; }
        }

        public new void Borrar()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.WriteLine(" ");
        }

        public void DibujarBala(ref bool disparar)
        {
            
            Console.SetCursorPosition(this.x, this.y);
            Console.WriteLine("|");
            if(this.y == 0) { Desaparecer(ref disparar); }
        }

        public void Desaparecer(ref bool disparar)
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.WriteLine(" ");
            disparar = true;
        }
        public void DibujarBalaEnemigo(ref bool disparar)
        {

            Console.SetCursorPosition(this.x, this.y);
            Console.WriteLine("|");
            if (this.y == 28) { Desaparecer(ref disparar); }
        }
    }
}
