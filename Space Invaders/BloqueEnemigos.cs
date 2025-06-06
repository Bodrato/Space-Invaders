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
        private bool derecha = true;
        private int desplazamientoY = 0;
        private readonly int[] baseY = { 5, 7, 9 };

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

        public void MoverBloque()
        {
            if (derecha && enemigos[0, 9].x >= 118)
            {
                derecha = false;
                desplazamientoY++;
            }

            if (!derecha && enemigos[0, 0].x <= 1)
            {
                derecha = true;
                desplazamientoY++;
            }

            BorrarBloque();

            for (int fila = 0; fila < enemigos.GetLength(0); fila++)
            {
                for (int i = 0; i < enemigos.GetLength(1); i++)
                {
                    int nuevoX = derecha ? enemigos[fila, i].x + 1 : enemigos[fila, i].x - 1;
                    int nuevoY = baseY[fila] + desplazamientoY;
                    enemigos[fila, i].MoverA(nuevoX, nuevoY);
                }
            }

            Dibujar();
        }

        public int PosicionYInferior()
        {
            int max = 0;
            for (int i = 0; i < enemigos.GetLength(1); i++)
            {
                if (enemigos[2, i].Activo && enemigos[2, i].y > max)
                {
                    max = enemigos[2, i].y;
                }
            }
            return max;
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

