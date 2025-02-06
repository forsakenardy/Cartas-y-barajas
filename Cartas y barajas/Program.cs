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
            int cantidadJugadores = PedirCantidadJugadores();

            Jugadores jugadores = new Jugadores(baraja);

            jugadores.CrearJugadores(cantidadJugadores);

            baraja.Barajar();

            jugadores.RepartirTodasCartas();

            Juego.IniciarJuego(jugadores.JugadoresList);

            Juego.Rondas();
            Console.ReadKey();
        }

        public static int PedirCantidadJugadores()
        {
            int cantidadJugadores = 0;
            while (cantidadJugadores < 2 || cantidadJugadores > 5)
            {
                Console.Write("Ingrese la cantidad de jugadores (de 2 a 5): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out cantidadJugadores) && cantidadJugadores >= 2 && cantidadJugadores <= 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido entre 2 y 5.");
                }
            }

            return cantidadJugadores;
        }
    }
}
