using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartas_y_barajas
{
    internal class Jugadores
    {
        public List<List<Carta>> JugadoresList { get; private set; }
        private Baraja baraja;

        public Jugadores(Baraja baraja)
        {
            this.baraja = baraja;
            JugadoresList = new List<List<Carta>>();
        }

        public void CrearJugadores(int numeroJugadores)
        {
            for (int i = 0; i < numeroJugadores; i++)
            {
                JugadoresList.Add(new List<Carta>());
            }
        }

        public void RepartirTodasCartas()
        {
            int jugadorIndex = 0;

            while (baraja.Mazo.Count > 0)
            {
                Carta carta = baraja.RobarPrimeraCarta();
                JugadoresList[jugadorIndex].Add(carta);

                jugadorIndex = (jugadorIndex + 1) % JugadoresList.Count;

            }

            Console.WriteLine("Todas las cartas han sido repartidas.");
            Console.ReadKey();
            Console.WriteLine(JugadoresList[jugadorIndex]);
        }
    }
}
