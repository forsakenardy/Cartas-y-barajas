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
        private Random random;

        public List<Carta> Mazo
        {
            get { return mazo; }
        }

        public Baraja()
        {
            mazo = CrearCartas();
            random = new Random();
        }

        public  List<Carta> CrearCartas()
        {
            mazo = new List<Carta>();

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

        public Carta RobarCarta(int indice)
        {
            if (mazo.Count > 0 && indice >= 0 && indice < mazo.Count)
            {
                Carta carta = mazo[indice];
                mazo.RemoveAt(indice);
                return carta;
            }
            Console.WriteLine("Índice fuera de rango o no hay más cartas en el mazo.");
            return null;
        }

        public Carta RobarPrimeraCarta() => RobarCarta(0);

        public Carta RobarCartaPorIndice(int indice) => RobarCarta(indice);

        public Carta RobarCartaAleatoria() => RobarCarta(random.Next(mazo.Count));

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
