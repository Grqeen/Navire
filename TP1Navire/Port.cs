using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TP1Navire
{
    class Port
    {
        private readonly string nom;
        private int nbNaviresMax = 5;
        private List<Navire> navires;

        //constructeur
        public Port(string nom)
        {
            this.nom = nom;
            navires = new List<Navire>();
        }

        // Methods
        public void EnregistrerArrivee(Navire navire)
        {
            if (this.navires.Count < this.nbNaviresMax)
            {
                this.navires.Add(navire);
            }
            else
            {
                throw new Exception("Ajout impossible, le port est complet");
            }
        }

        private int RecupPosition(String imo)
        {
            int i = 0;

            while (i < this.navires.Count && this.navires[i].Imo != imo)
            {
                i++;
            }
            if (i < this.navires.Count)
            {
                return i;
            }
            else
            {
                return -1;
            }

        }

        private int RecupPosition(Navire navire)
        {
            //return this.RecupPosition(navire.Imo);
            if (this.navires.Contains(navire))
            {
                return this.navires.IndexOf(navire);
            }
            else
            {
                return -1;
            }
        }

        //accesseur
        public string Nom => nom;
        public void TesterRecupPosition()
        {
            this.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827));
            this.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
            this.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
            String imo = "IMO9427639";
            Console.WriteLine("Indice du navire " + imo + " dans la collection : " + this.RecupPosition(imo));
            imo = "IMO8715871";
            Console.WriteLine("Indice du navire " + imo + " dans la collection : " + this.RecupPosition(imo));
            imo = "IMO1111111";
            Console.WriteLine("Indice du navire " + imo + " dans la collection : " + this.RecupPosition(imo));
        }
        public void TesterRecupPositionV2()
        {
            Navire navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
            this.EnregistrerArrivee(navire);
            this.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
            this.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
            Console.WriteLine("Indice du navire " + navire.Imo + " dans la collection : " + this.RecupPosition(navire));
            Navire unAutreNavire = new Navire("IMO8715871", "MSC PILAR");
            Console.WriteLine("Indice du navire " + unAutreNavire.Imo + " dans la collection : " + this.RecupPosition(unAutreNavire));
            unAutreNavire = new Navire("IMO8715871", "MSC PILAR", "Porte canteneurs", 52181);
            Console.WriteLine("Indice du navire " + unAutreNavire.Imo + " dans la collection : " + this.RecupPosition(unAutreNavire));
        }

        public void EnregistrerDepart(String imo)
        {
            int index = this.RecupPosition(imo);
            if (index >= 0)
            {
                // le navire est présent dans le port
                this.navires.RemoveAt(index);
            }
            else
            {
                // le navire n'est pas dans le port
                throw new Exception("impossible d'enregistrer le départ du navire " + imo + ", il n'est pas dans le port ");
            }
        }

        public bool EstPresent(String imo)
        {
            return (this.RecupPosition(imo) >= 0);
        }


        /// <summary>
        ///  première version qui sera remplacée par EstPresent
        /// </summary>
        /// <param name="imo"></param>
        /// <returns></returns>
        public bool EstPresentV0(String imo)
        {
            int i = 0;
            while (i < this.navires.Count && this.navires[i].Imo != imo)
            { i++; }
            return i < this.navires.Count;
        }




    }



}
