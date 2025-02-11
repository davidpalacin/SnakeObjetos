using System;
using System.Threading;

namespace SnakeObjetos
{
    internal class Partida
    {
        private Snake snake = new Snake(10, 10, 1);
        private Cuadricula cuadricula = new Cuadricula(20, 20);
        private Comida comida = new Comida(5, 5);

        public void IniciarJuego()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al juego del Snake!");
            Console.CursorVisible = false;

            cuadricula.Dibujar();
            snake.Dibujar();
            comida.Dibujar();

            while (true) // Bucle infinito del juego
            {
                // Detectar entrada del usuario (sin bloquear)
                if (Console.KeyAvailable)
                {
                    var tecla = Console.ReadKey(true).Key;
                    switch (tecla)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            snake.CambiarDireccion(Direccion.Arriba);
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            snake.CambiarDireccion(Direccion.Abajo);
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            snake.CambiarDireccion(Direccion.Izquierda);
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            snake.CambiarDireccion(Direccion.Derecha);
                            break;
                    }
                }

                // Mover la serpiente
                snake.Mover();

                // Colisión con tablero o consigo misma
                if (snake.HaColisionado(20, 20) || snake.HaColisionadoConCuerpo())
                {
                    Console.Clear();
                    Console.WriteLine("¡Has perdido! Presiona cualquier tecla para salir...");
                    Console.ReadKey();
                    break; // Termina el juego
                }

                // Redibujar la serpiente
                Console.Clear();
                cuadricula.Dibujar();
                snake.Dibujar();

                // Control de velocidad del juego
                Thread.Sleep(150);
            }
        }
    }
}
