using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartas_y_barajas
{
    internal class Juego
    {
        private List<Carta> Jugador1;
        private List<Carta> Jugador2;
        private Baraja baraja;

        public Juego(Baraja baraja)
        {
            this.baraja = baraja;
            Jugador1 = new List<Carta>();
            Jugador2 = new List<Carta>();
        }

        public void RepartirCartas()
        {
            bool turnoJugador1 = true;

            while (baraja.Mazo.Count > 0)
            {
                Carta carta = baraja.RobarPrimeraCarta();
                if (turnoJugador1)
                    Jugador1.Add(carta);
                else
                    Jugador2.Add(carta);

                turnoJugador1 = !turnoJugador1;
            }

            baraja.Mazo.Clear();

            Console.WriteLine("Todas las cartas han sido repartidas y el mazo está vacío.");
            Console.ReadKey();
        }

        public void Rondas()
        {
            while (Jugador1.Count > 0 || Jugador2.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"El jugador1 lanza el {Jugador1[0].Numero} de {Jugador1[0].Palo}");
                Console.ReadKey();
                Console.WriteLine($"El jugador2 lanza el {Jugador2[0].Numero} de {Jugador2[0].Palo}");
                Console.ReadKey();
                Console.Clear();

                List<Carta> cartasEnJuego = new List<Carta>{Jugador1[0],Jugador2[0]};

                while (Jugador1[0].Numero == Jugador2[0].Numero)
                {
                    Console.WriteLine("Es un empate, buscando más cartas...");

                    Jugador1.RemoveAt(0);
                    Jugador2.RemoveAt(0);

                    cartasEnJuego.Add(Jugador1[0]);
                    cartasEnJuego.Add(Jugador2[0]);

                    Console.ReadKey();
                    Console.WriteLine($"El jugador1 lanza el {Jugador1[0].Numero} de {Jugador1[0].Palo}");
                    Console.ReadKey();
                    Console.WriteLine($"El jugador2 lanza el {Jugador2[0].Numero} de {Jugador2[0].Palo}");
                    Console.ReadKey();
                }

                if (Jugador1[0].Numero > Jugador2[0].Numero)
                {
                    Console.WriteLine($"El jugador 1 gana la ronda y obtiene todas las cartas.");
                    Jugador1.AddRange(cartasEnJuego);
                }

                else if (Jugador2[0].Numero > Jugador1[0].Numero)
                {
                    Console.WriteLine($"El jugador 2 gana la ronda y obtiene todas las cartas.");
                    Jugador2.AddRange(cartasEnJuego);
                }

                Jugador1.RemoveAt(0);
                Jugador2.RemoveAt(0);

                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"A el jugador1 le quedan {Jugador1.Count} cartas" +
                    $" y al Jugador2 le quedan {Jugador2.Count} cartas");
                Console.WriteLine("Siguiente ronda");
                Console.ReadKey();
            }
        }
    }
}
