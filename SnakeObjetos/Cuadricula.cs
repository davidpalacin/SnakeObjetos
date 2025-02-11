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

        // Métodos
        static void Crear(int filas, int columnas)
        {
            for (int i = 0; i < filas; i++)
            {
                Console.WriteLine("_");
                for (int j = 0; j < columnas; j++)
                {
                    Console.WriteLine(" | ");
                }
            }
        }
    }
}
