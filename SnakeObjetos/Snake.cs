using System;
using System.Collections.Generic;

namespace SnakeObjetos
{
    internal class Snake
    {
        public List<(int x, int y)> Cuerpo { get; private set; }
        public Direccion DireccionActual { get; private set; }
        private char Simbolo = 'O';

        public Snake(int xInicial, int yInicial, int longitud)
        {
            Cuerpo = new List<(int x, int y)>();

            // Crear la serpiente con la longitud inicial
            for (int i = 0; i < longitud; i++)
            {
                Cuerpo.Add((xInicial - i, yInicial)); // Se genera horizontal hacia la derecha
            }

            DireccionActual = Direccion.Derecha;
        }

        public void Mover()
        {
            // Guardamos la última posición antes de moverse
            var ultimaPosicion = Cuerpo[Cuerpo.Count - 1];

            // Mover el cuerpo de la serpiente (excepto la cabeza)
            for (int i = Cuerpo.Count - 1; i > 0; i--)
            {
                Cuerpo[i] = Cuerpo[i - 1]; // Desplaza los segmentos
            }

            // Mover la cabeza en la dirección actual
            switch (DireccionActual)
            {
                case Direccion.Arriba:
                    Cuerpo[0] = (Cuerpo[0].x, Cuerpo[0].y - 1);
                    break;
                case Direccion.Abajo:
                    Cuerpo[0] = (Cuerpo[0].x, Cuerpo[0].y + 1);
                    break;
                case Direccion.Izquierda:
                    Cuerpo[0] = (Cuerpo[0].x - 2, Cuerpo[0].y);
                    break;
                case Direccion.Derecha:
                    Cuerpo[0] = (Cuerpo[0].x + 2, Cuerpo[0].y);
                    break;
            }

            // Borrar la última posición para evitar parpadeo
            Console.SetCursorPosition(ultimaPosicion.x, ultimaPosicion.y);
            Console.Write(" ");

            // Dibujar la nueva cabeza
            Console.SetCursorPosition(Cuerpo[0].x, Cuerpo[0].y);
            Console.Write("█");
        }


        public void Dibujar()
        {
            foreach (var parte in Cuerpo)
            {
                Console.SetCursorPosition(parte.x, parte.y);
                Console.Write(Simbolo);
            }
        }

        public void CambiarDireccion(Direccion nuevaDireccion)
        {
            // Evitar que la serpiente se mueva en dirección opuesta
            if ((DireccionActual == Direccion.Arriba && nuevaDireccion == Direccion.Abajo) ||
                (DireccionActual == Direccion.Abajo && nuevaDireccion == Direccion.Arriba) ||
                (DireccionActual == Direccion.Izquierda && nuevaDireccion == Direccion.Derecha) ||
                (DireccionActual == Direccion.Derecha && nuevaDireccion == Direccion.Izquierda))
            {
                return;
            }

            DireccionActual = nuevaDireccion;
        }

        public bool HaColisionado(int ancho, int alto)
        {
            var cabeza = Cuerpo[0];

            // Si la cabeza está fuera de los límites, hay colisión
            if (cabeza.x <= 0 || cabeza.x >= ancho * 2 || cabeza.y <= 0 || cabeza.y >= alto)
            {
                return true;
            }
            return false;
        }

        public bool HaColisionadoConCuerpo()
        {
            var cabeza = Cuerpo[0];

            // Verificar si la cabeza se encuentra en alguna otra parte del cuerpo
            for (int i = 1; i < Cuerpo.Count; i++) // Empieza desde 1 para ignorar la cabeza
            {
                if (Cuerpo[i] == cabeza)
                {
                    return true; // Colisión detectada
                }
            }
            return false;
        }

        public void Crecer()
        {
            // Añadir un nuevo segmento en la última posición de la cola
            Cuerpo.Add(Cuerpo[Cuerpo.Count - 1]);
        }

        public bool HaComido(Comida comida)
        {
            return Cuerpo[0].x == comida.X && Cuerpo[0].y == comida.Y;
        }
    }

    public enum Direccion
    {
        Arriba,
        Abajo,
        Izquierda,
        Derecha
    }
}
