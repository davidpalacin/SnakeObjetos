using System;
using System.Threading;

namespace SnakeObjetos
{
    internal class Partida
    {
        private Snake snake = new Snake(10, 10, 1);
        private Cuadricula cuadricula = new Cuadricula(20, 20);
        private Comida comida;
        private int puntuacion = 0;

        public int Puntuacion { get; private set; }

        private void MostrarPuntuacion()
        {
            Console.SetCursorPosition(0, 0); // Colocamos el cursor en la parte superior
            Console.Write($"Puntuación: {puntuacion}");
        }


        public void IniciarJuego()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al juego del Snake!");
            Console.CursorVisible = false;

            comida = new Comida(20, 20, snake.Cuerpo); // Crear comida inicial

            cuadricula.Dibujar();
            comida.Dibujar();
            snake.Dibujar();

            while (true)
            {
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

                // Mover la serpiente sin borrar toda la pantalla
                snake.Mover();

                // Verificar colisión
                if (snake.HaColisionado(20, 20) || snake.HaColisionadoConCuerpo())
                {
                    Console.SetCursorPosition(0, 20 + 2);
                    Console.WriteLine("¡Has perdido! Presiona cualquier tecla para salir...");
                    Console.ReadKey();
                    break;
                }

                // Si la serpiente ha comido la comida
                if (snake.HaComido(comida))
                {
                    snake.Crecer();
                    comida.GenerarNuevaPosicion(20, 20, snake.Cuerpo); // Evitar colisión
                    comida.Dibujar();
                    puntuacion += 10;
                    MostrarPuntuacion();
                }


                // Control de velocidad
                Thread.Sleep(150);
            }

        }
    }
}
