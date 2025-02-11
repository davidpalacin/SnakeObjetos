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
            // Obtener la cabeza actual
            var cabeza = Cuerpo[0];
            (int x, int y) nuevaCabeza = cabeza;

            // Cambiar la posición de la cabeza según la dirección
            switch (DireccionActual)
            {
                case Direccion.Arriba:
                    nuevaCabeza.y--;
                    break;
                case Direccion.Abajo:
                    nuevaCabeza.y++;
                    break;
                case Direccion.Izquierda:
                    nuevaCabeza.x -= 2;
                    break;
                case Direccion.Derecha:
                    nuevaCabeza.x += 2;
                    break;
            }

            // Insertar la nueva cabeza al inicio de la lista
            Cuerpo.Insert(0, nuevaCabeza);

            // Eliminar la última posición para simular el movimiento
            Cuerpo.RemoveAt(Cuerpo.Count - 1);
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

    }

    public enum Direccion
    {
        Arriba,
        Abajo,
        Izquierda,
        Derecha
    }
}
