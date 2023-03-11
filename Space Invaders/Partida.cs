using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Partida
    {
        public void Lanzar(Bienvenida welcome)
        {
            BloqueEnemigos bloqueEnemigos = new BloqueEnemigos();
            Nave nave = new Nave();
            Disparo disparo = new Disparo();
            Disparo disparoEnemigo = new Disparo();
            Ovni ovni = new Ovni();
            Marcador marcador = new Marcador();
            Torres torreIzq = new Torres(30,20);
            Torres torreCentro = new Torres(60, 20);
            Torres torreDrch = new Torres(90, 20);

            ConsoleKeyInfo tecla = new ConsoleKeyInfo();

            int Y = nave.y;
            bool poderDisparar = true, poderDispararEnemigo = true;
            int xEnemigo = 0, yEnemigo = 0;
            int enemigosMuertos = 0;
            do
            {
                Thread.Sleep(50);
                bloqueEnemigos.MoverBloque();
                nave.Dibujar();
                ovni.Mover();
                marcador.Dibujar();

                if (!poderDisparar) 
                { 
                    disparo.Lanzar(nave.x, Y, ref poderDisparar);
                    if (bloqueEnemigos.ColisionaCon(disparo))
                    {
                        disparo.Desaparecer(ref poderDisparar);
                        marcador.Puntuacion += 10;
                        enemigosMuertos++;
                    }

                    if (disparo.ColisionaCon(ovni))
                    {
                        ovni.Desaparecer();
                        disparo.Desaparecer(ref poderDisparar);
                        marcador.Puntuacion += 50;
                    }

                    if (torreIzq.ColisionaCon(disparo)) { disparo.Desaparecer(ref poderDisparar); }

                    if (torreCentro.ColisionaCon(disparo)) { disparo.Desaparecer(ref poderDisparar); }

                    if (torreDrch.ColisionaCon(disparo)) { disparo.Desaparecer(ref poderDisparar); }
                }

                if (poderDispararEnemigo)
                {
                    Random random = new Random();
                    (int, int)[] posiciones = new (int, int)[30];
                    int posicion = 0;

                    for (int y = 0; y < 3; y++)
                        for (int x = 0; x < 10; x++)
                            if (bloqueEnemigos.enemigos[y, x].Activo)
                                posiciones[posicion++] = (x, y);

                    int nrandom = random.Next(0, posicion - 1);
                    (int x, int y) posicionRandom = posiciones[nrandom];

                    xEnemigo = posicionRandom.x; yEnemigo = posicionRandom.y;
                    disparoEnemigo.LanzarEnemigo(bloqueEnemigos.enemigos[yEnemigo, xEnemigo].x, bloqueEnemigos.enemigos[yEnemigo, xEnemigo].y, ref poderDispararEnemigo);
                }
                else { disparoEnemigo.LanzarEnemigo(bloqueEnemigos.enemigos[yEnemigo, xEnemigo].x, bloqueEnemigos.enemigos[yEnemigo, xEnemigo].y, ref poderDispararEnemigo); }

                if (!poderDispararEnemigo)
                {
                    if (nave.ColisionaCon(disparoEnemigo))
                    {
                        disparoEnemigo.Desaparecer(ref poderDispararEnemigo);
                        marcador.Vidas--;
                    }

                    if (torreIzq.ColisionaCon(disparoEnemigo)) { disparoEnemigo.Desaparecer(ref poderDispararEnemigo); }

                    if (torreCentro.ColisionaCon(disparoEnemigo)) { disparoEnemigo.Desaparecer(ref poderDispararEnemigo); }

                    if (torreDrch.ColisionaCon(disparoEnemigo)) { disparoEnemigo.Desaparecer(ref poderDispararEnemigo); }
                }
                
                if (Console.KeyAvailable)
                {
                    tecla = Console.ReadKey(true);
                    while (Console.KeyAvailable) { Console.ReadKey(); }
                    if (tecla.Key == ConsoleKey.LeftArrow) { nave.MoverIzquierda(); }
                    if (tecla.Key == ConsoleKey.RightArrow) { nave.MoverDerecha(); }
                    if (poderDisparar) { if (tecla.Key == ConsoleKey.Spacebar) { disparo.Lanzar(nave.x,Y, ref poderDisparar); } }
                }  
            } while(tecla.Key != ConsoleKey.Escape && marcador.Vidas != 0 && enemigosMuertos != 30);

            if (marcador.Vidas == 0)
            {
                Console.Clear();
                Console.SetCursorPosition(50, 10);
                Console.Write("Game Over!");
                if(marcador.Puntuacion > welcome.mejorPuntuacion) { welcome.mejorPuntuacion = marcador.Puntuacion; }
                Thread.Sleep(5000);
            }

            if(enemigosMuertos == 30)
            {
                Console.Clear();
                Console.SetCursorPosition(50, 10);
                Console.Write("You have won!");
                if (marcador.Puntuacion > welcome.mejorPuntuacion) { welcome.mejorPuntuacion = marcador.Puntuacion; }
                Thread.Sleep(5000);
            }
        }
    }
}
