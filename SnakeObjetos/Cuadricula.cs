using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeObjetos
{
    internal class Cuadricula
    {
        private int filas;
        private int columnas;

        public Cuadricula(int f, int c)
        {
            this.filas = f;
            this.columnas = c;
        }

        public void Dibujar()
        {
            Console.Clear(); // Limpiar pantalla antes de dibujar
            Console.CursorVisible = false; // Ocultar cursor para evitar parpadeo

            for (int i = 0; i <= filas; i++)
            {
                for (int j = 0; j <= columnas; j++)
                {
                    // Dibujar bordes
                    if (i == 0 || i == filas)
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write("-");
                    }
                    else if (j == 0 || j == columnas)
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write("|");
                    }
                }
            }
        }
    }
}

