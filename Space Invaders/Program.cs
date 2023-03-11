using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(width: 120, height: 30);
            Console.CursorVisible = false;
            Juego juego = new Juego();
            juego.Lanzar();
        }
    }
}
