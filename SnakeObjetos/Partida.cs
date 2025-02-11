using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeObjetos
{
    internal class Partida
    {
        // Atributos

        public Partida() { }

        private Snake snake = new Snake();
        private Cuadricula  cuadricula = new Cuadricula(20, 20);




        // Métodos
        public void IniciarJuego()
        {
            Console.WriteLine("Bienvenido");
        }
    }
}
