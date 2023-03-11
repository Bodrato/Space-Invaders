using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Bienvenida
    {
        bool salir = false;
        public int mejorPuntuacion { get; set; }
        public void Lanzar()
        {
            bool fin = false;
            Console.SetCursorPosition(25, 10);
            Console.WriteLine("Bienvenido en Space Invaders. Pulsa intro para jugar o ESC para salir");
            Console.SetCursorPosition(25, 15);
            Console.WriteLine("Mejor puntuación: {0}", mejorPuntuacion);
            while (!fin)
            { 
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.Escape) { salir = true; fin = true; }
                else 
                {
                    if (tecla.Key == ConsoleKey.Enter) { fin = true; }
                }
            }
        }

        public bool GetSalir()
        {
            return salir;
        }
    }
}
