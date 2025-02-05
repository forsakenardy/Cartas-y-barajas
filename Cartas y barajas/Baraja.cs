using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartas_y_barajas
{
    internal class Baraja
    {
        private List<Carta> mazo;
        private List<Carta> cartasRobadas;
        private Random random;

        public Baraja()
        {
            mazo = CrearCartas();
            cartasRobadas = new List<Carta>();
            random = new Random();
        }

        public List<Carta> Mazo
        {
            get { return mazo; }
        }

        public  List<Carta> CrearCartas()
        {
            List<Carta> mazo = new List<Carta>();

            string[] palos = { "corazones", "picas", "diamantes", "tréboles" };

            for (int numero = 1; numero <= 13; numero++)
            {
                foreach (string palo in palos)
                {
                    mazo.Add(new Carta(numero, palo));
                }
            }

            return mazo;
        }

        public void Barajar()
        {
            for (int i = 0; i < mazo.Count; i++)
            {
                int j = random.Next(mazo.Count);
                (mazo[i], mazo[j]) = (mazo[j], mazo[i]);
            }
            Console.WriteLine("El mazo ha sido barajado.");
        }

        public Carta RobarPrimeraCarta()
        {
            if (mazo.Count > 0)
            {
                Carta carta = mazo[0];
                mazo.RemoveAt(0);
                cartasRobadas.Add(carta);
                return carta;
            }
            Console.WriteLine("No hay más cartas en el mazo.");
            return null;
        }

        public Carta RobarCartaPorIndice(int indice)
        {
            if (indice >= 0 && indice < mazo.Count)
            {
                Carta carta = mazo[indice];
                mazo.RemoveAt(indice);
                cartasRobadas.Add(carta);
                return carta;
            }
            Console.WriteLine("Índice fuera de rango.");
            return null;
        }

        public Carta RobarCartaAleatoria()
        {
            if (mazo.Count > 0)
            {
                int indice = random.Next(mazo.Count);
                Carta carta = mazo[indice];
                mazo.RemoveAt(indice);
                cartasRobadas.Add(carta);
                return carta;
            }
            Console.WriteLine("No hay más cartas en el mazo.");
            return null;
        }

        public void MostrarMazo()
        {
            Console.WriteLine("\nCartas en el mazo:");
            foreach (Carta carta in mazo)
            {
                Console.WriteLine($"{carta.Numero} de {carta.Palo}");
            }
        }
    }
}
