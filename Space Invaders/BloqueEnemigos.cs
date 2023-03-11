using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class BloqueEnemigos : Enemigo
    {
        public Enemigo[,] enemigos { get; set; }
        public BloqueEnemigos()
        {
            this.enemigos = new Enemigo[3, 10];
            RellenarBloque();
        }

        public void RellenarBloque()
        {
            int x = 15;
            for (int i = 0; i < 10; i++)
            {
                enemigos[0, i] = new Enemigo(x, 5);
                enemigos[1, i] = new Enemigo2(x, 7);
                enemigos[2, i] = new Enemigo3(x, 9);
                x = x + 10;
            }
        }

        public override void Dibujar()
        {
            for (int i = 0; i < 10; i++)
            {
                enemigos[0, i].Dibujar();
                enemigos[1, i].Dibujar();
                enemigos[2, i].Dibujar();
            }
        }
        bool c = true;

        public void MoverBloque()
        { 
           if (enemigos[0,0].x == 1)
           {
                c = true;
           }

            if (enemigos[0,9].x == 118)
            {
                c = false;
            }

            BorrarBloque();

            if (c)
            {
                for(int i = 0; i < enemigos.GetLength(1); i++)
                {
                    enemigos[0, i].MoverA(enemigos[0, i].x + 1, 5);
                    enemigos[1, i].MoverA(enemigos[1, i].x + 1, 7);
                    enemigos[2, i].MoverA(enemigos[2, i].x + 1, 9);
                }
            }
            else
            {
                for (int i = 0; i < enemigos.GetLength(1); i++)
                {
                    enemigos[0, i].MoverA(enemigos[0, i].x - 1, 5);
                    enemigos[1, i].MoverA(enemigos[1, i].x - 1, 7);
                    enemigos[2, i].MoverA(enemigos[2, i].x - 1, 9);                   
                }
            }
            Dibujar();
        }

        public void BorrarBloque()
        {
            for (int i = 0; i < 10; i++)
            {
                enemigos[0, i].Borrar();
                enemigos[1, i].Borrar();
                enemigos[2, i].Borrar();
            }
        }

        public override bool ColisionaCon (Sprite sprite)
        {
            for(int i = 0; i < this.enemigos.GetLength(0); i++)
            {
                for (int j = 0; j < this.enemigos.GetLength(1); j++)
                {
                    if (this.enemigos[i, j].y == sprite.y && (this.enemigos[i,j].x == sprite.x || this.enemigos[i, j].x + 1 == sprite.x || this.enemigos[i,j].x + 2 == sprite.x))
                    {
                        if (this.enemigos[i, j].Activo)
                        {
                            this.enemigos[i, j].Activo = false;
                            this.enemigos[i, j].Borrar();
                            this.enemigos[i, j].Imagen = " ";
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}

