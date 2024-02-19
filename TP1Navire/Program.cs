using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TP1Navire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //TesterInstanciations();
                //TesterEnregistrerArrivee();
                //TesterRecupPosition();
                TesterRecupPositionV2();
                //TesterEnregistrerDepart();
                //TesterEstPresent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.ReadKey();
        }

        public static void TesterInstanciations()
        {
            // declaration de l'objet unNavire de la classe Navire
            Navire unNavire;
            // Instantiation de l'objet
            unNavire = new Navire("IM09427639", "Copper Spirit", "Hydrocarbures", 156827);
            Affiche(unNavire);
            Console.WriteLine("--------------------------");

            // Declaration ET instantiation d'un autre objet de la classe Navire
            Navire unAutreNavire = new Navire("IM09839272", "MSC Isabella", "Porte-conteneurs", 197500);
            Affiche(unAutreNavire);
            Console.WriteLine("--------------------------");

            unAutreNavire = new Navire("IM08715871", "MSC PILAR");
            Affiche(unAutreNavire);
        }

        public static void Affiche(Navire navire)
        {
            Console.WriteLine(navire);
        }

        public static void TesterEnregistrerArrivee()
        {
            Port port = new Port("Toulon");
            port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella","Porte-conteneur", 5));
            port.EnregistrerArrivee(new Navire("IMO9839273", "Bateau 1", "Type bateau 1", 6));
            port.EnregistrerArrivee(new Navire("IMO9839274", "Bateau 2 ", "Type bateau 2", 7));
            port.EnregistrerArrivee(new Navire("IMO9839275", "Bateau 3 ", "Type bateau 3", 8));
            port.EnregistrerArrivee(new Navire("IMO9839276", "Bateau 4 ", "Type bateau 4", 9));
            port.EnregistrerArrivee(new Navire("IMO9839277", "Bateau 5 ", "Type bateau 5", 10));

            Console.WriteLine("Navires bien enregistrés dans le port");
        }

        public static void TesterRecupPosition()
        {
            (new Port("Toulon")).TesterRecupPosition();
        }

        public static void TesterRecupPositionV2()
        {
            (new Port("Toulon")).TesterRecupPositionV2();
        }

        public static void TesterEnregistrerDepart()
        {
            Port port = new Port("Toulon");
            port.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827));
            port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
            port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
            port.EnregistrerDepart("IMO8715871");
            Console.WriteLine("Départ du navire IMO8715871 enregistré");
            port.EnregistrerDepart("IMO1111111");
            Console.WriteLine("Départ du navire IMO1111111 enregistré");
            Console.WriteLine("fin des enregistrements des départs");
        }

        public static void TesterEstPresent()
        {
            Port port = new Port("Toulon");
            port.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827));
            port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
            port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
            String imo = "IMO9427639";
            Console.WriteLine("Le navire " + imo + " est présent dans le port : " + port.EstPresent(imo));
            imo = "IMO1111111";
            Console.WriteLine("Le navire " + imo + " est présent dans le port : " + port.EstPresent(imo));
        }
    }
}
