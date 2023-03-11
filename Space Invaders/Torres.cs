using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Torres : Sprite
    {
        public string p1 { get; set; }
        public string p2 { get; set; }
        public string p3 { get; set; }
        public string p4 { get; set; }
        public string p5 { get; set; }
        public string p6 { get; set; }

        public Torres(int x, int y)
        {
            this.x = x;
            this.y = y;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("******");
            p1 = "*"; p2 = "*"; p3= "*"; p4 = "*"; p5 = "*"; p6 = "*";
            Activo = true;
        }

        public new void Borrar()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.WriteLine(" ");
        }

        public override bool ColisionaCon(Sprite sprite)
        {
            if (this.x == sprite.x && this.y == sprite.y) { if (p1 == "*") { p1 = " "; return true; } else { return false; } }
            if (this.x+1 == sprite.x && this.y == sprite.y) { if (p2 == "*") { p2 = " "; return true; } else { return false; } }
            if (this.x+2 == sprite.x && this.y == sprite.y) { if (p3 == "*") { p3 = " "; return true; } else { return false; } }
            if (this.x+3 == sprite.x && this.y == sprite.y) { if (p4 == "*") { p4 = " "; return true; } else { return false; } }
            if (this.x+4 == sprite.x && this.y == sprite.y) { if (p5 == "*") { p5 = " "; return true; } else { return false; } }
            if (this.x+5 == sprite.x && this.y == sprite.y) { if (p6 == "*") { p6 = " "; return true; } else { return false; } }

            return false;
        }
    }
}
