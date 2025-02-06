using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartas_y_barajas
{
    internal class Juego
    {
        private static List<List<Carta>> jugadores;

        public static void IniciarJuego(List<List<Carta>> jugadoresList)
        {
            if (jugadoresList == null || jugadoresList.Count == 0)
            {
                throw new ArgumentException("La lista de jugadores no puede ser nula o vacía.");
            }

            jugadores = jugadoresList;
            Rondas();
        }

        public static void Rondas()
        {
            while (jugadores.Any(j => j.Count > 0))
            {
                Console.Clear();
                Console.WriteLine("Iniciando nueva ronda...");
                JugarRonda();
                Console.WriteLine("Siguiente ronda...");
                Console.ReadKey();
            }

            Console.WriteLine("Juego terminado.");
        }

        private static void JugarRonda()
        {
            List<Carta> cartasEnJuego = new List<Carta>();
            List<int> jugadoresActivos = new List<int>();

            for (int i = 0; i < jugadores.Count; i++)
            {
                if (jugadores[i].Count > 0)
                {
                    Carta carta = jugadores[i][0];
                    Console.WriteLine($"El jugador {i + 1} lanza el {carta.Numero} de {carta.Palo}");
                    Console.ReadKey();
                    cartasEnJuego.Add(carta);
                    jugadoresActivos.Add(i);
                }
            }

            int ganadorIndex = ResolverEmpates(cartasEnJuego, jugadoresActivos);

            if (ganadorIndex != -1)
            {
                Console.WriteLine($"El jugador {ganadorIndex + 1} gana la ronda y obtiene todas las cartas.");
                Console.ReadKey();
                Console.Clear();
                jugadores[ganadorIndex].AddRange(cartasEnJuego);
            }

            foreach (int jugadorIndex in jugadoresActivos)
            {
                if (jugadores[jugadorIndex].Count > 0)
                {
                    jugadores[jugadorIndex].RemoveAt(0);
                }
            }

            for (int i = 0; i < jugadores.Count; i++)
            {
                if (jugadores[i].Count > 0)
                    Console.WriteLine($"Al jugador {i + 1} le quedan {jugadores[i].Count} cartas.");
                else
                    Console.WriteLine($"El jugador {i + 1} se ha quedado sin cartas.");
            }
        }

        private static int ResolverEmpates(List<Carta> cartasEnJuego, List<int> jugadoresActivos)
        {
            while (true)
            {
                int maxNumero = cartasEnJuego.Max(c => c.Numero);
                List<int> jugadoresEmpatados = jugadoresActivos
                    .Where(i => jugadores[i].Count > 0 && jugadores[i][0].Numero == maxNumero)
                    .ToList();

                if (jugadoresEmpatados.Count == 1)
                {
                    return jugadoresEmpatados[0];
                }

                Console.WriteLine("Empate entre jugadores: " + string.Join(", ", jugadoresEmpatados.Select(j => j + 1)));

                List<int> jugadoresQuePuedenSeguir = jugadoresEmpatados
                    .Where(j => jugadores[j].Count > 1)
                    .ToList();

                if (jugadoresQuePuedenSeguir.Count == 0)
                {
                    Console.WriteLine("Todos los jugadores empatados se han quedado sin cartas. Las cartas quedan en el mazo.");
                    return -1;
                }

                jugadoresActivos = new List<int>(jugadoresQuePuedenSeguir);

                foreach (int jugadorIndex in jugadoresQuePuedenSeguir)
                {
                    jugadores[jugadorIndex].RemoveAt(0);
                }

                cartasEnJuego.Clear();
                foreach (int jugadorIndex in jugadoresQuePuedenSeguir)
                {
                    if (jugadores[jugadorIndex].Count > 0)
                    {
                        Carta nuevaCarta = jugadores[jugadorIndex][0];
                        cartasEnJuego.Add(nuevaCarta);
                        Console.WriteLine($"El jugador {jugadorIndex + 1} lanza el {nuevaCarta.Numero} de {nuevaCarta.Palo} para el desempate.");
                    }
                }

                Console.ReadKey();
            }
        }
    }
}