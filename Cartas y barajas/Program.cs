using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartas_y_barajas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Baraja baraja = new Baraja();
            Juego juego = new Juego(baraja);

            baraja.Barajar();
            juego.RepartirCartas();
            juego.Rondas();

            Console.ReadKey();
        }
    }
}
