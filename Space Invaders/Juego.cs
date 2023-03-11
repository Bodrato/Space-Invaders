namespace Space_Invaders
{
    internal class Juego
    {
        public void Lanzar()
        {
           Bienvenida welcome = new Bienvenida();
           Partida game = new Partida();

            while (!welcome.GetSalir())
            {
                welcome.Lanzar();
                if (welcome.GetSalir()) { break; }
                Console.Clear();
                game.Lanzar(welcome);
                Console.Clear();
            }
           
        }
    }
}