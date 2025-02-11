using System;

namespace SnakeObjetos
{
    internal class Comida
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private char Simbolo = 'O'; // Caracter que representa la comida

        private Random random = new Random();

        public Comida(int ancho, int alto)
        {
            GenerarNuevaPosicion(ancho, alto);
        }

        public void GenerarNuevaPosicion(int ancho, int alto)
        {
            // Genera coordenadas aleatorias dentro de la cuadrícula (pares para alinearlo bien)
            X = random.Next(1, ancho) * 2;
            Y = random.Next(1, alto);
        }

        public void Dibujar()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Simbolo);
        }
    }
}

