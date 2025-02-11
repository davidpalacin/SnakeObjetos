using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeObjetos
{
    internal class Bomba

    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private char Simbolo = '#'; // Caracter que representa la bomba

        private Random random = new Random();

        public Bomba(int ancho, int alto, List<(int x, int y)> cuerpoSerpiente)
        {
            GenerarNuevaPosicion(ancho, alto, cuerpoSerpiente);
        }

        public void GenerarNuevaPosicion(int ancho, int alto, List<(int x, int y)> cuerpoSerpiente)
        {
            do
            {
                X = random.Next(1, ancho) * 2; // Coordenada X aleatoria (pares para alinear)
                Y = random.Next(1, alto); // Coordenada Y aleatoria
            }
            while (cuerpoSerpiente.Contains((X, Y))); // Repetir si la bomba está en la serpiente
        }


        public void Dibujar()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Simbolo);
        }
    }
}
