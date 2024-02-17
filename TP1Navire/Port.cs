using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TP1Navire
{
    internal class Port
    {

        private string name;
        private int nbNaviresMax;
        private List<Navire> navires;

        public Port(string name, List<Navire> navires)
        {
            this.name = name;
            this.nbNaviresMax = 5;
            this.navires = navires;
        }

        public void EnregistrerArrivee(Navire navire)
        {
            if (navires.Count < nbNaviresMax)
            {
                navires.Add(navire);
            }
            else 
            {
                throw new Exception("EnregistrerArrivee: Ajout impossible, le port est complet");
            }
        }

        public void EnregistrerDepart(String imo)
        {
            foreach(Navire Valimo in navires) 
            {
                if(Valimo.Imo == imo)
                {
                    navires.Remove(Valimo);
                    return;
                }       
                
                    
                    
            }
            throw new Exception("EnregistrerDepart : Impossible d'enregistrer le départ du navire " + imo + " ,il n'est pas dans le port");

        }

        public bool EstPresent(String imo)
        {
            foreach (Navire Valimo in navires)
            {
                if (Valimo.Imo == imo)
                {
                    return true;
                }
            }
            return false;
            
        }

        private int RecupPosition(String imo)
        {
            for (int i = 0; i < navires.Count; i++)
            {
                if(imo == navires[i].Imo)
                {
                    return i;
                }

            }
            return -1;
        }

        private int RecupPosition(Navire navire)
        {
            for (int i = 0; i < navires.Count; i++)
            {
                if (navire == navires[i])
                {
                    return i;
                }

            }
            return -1;
        }

        public void TesterRecupPosition()
        {
            this.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827));
            this.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
            this.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
            String imo = "IMO9427639";
            Console.WriteLine("Indice du navire " + imo + " dans la collection : " + this.RecupPosition(imo));
            imo = "IMO8715871";
            Console.WriteLine("Indice du navire " + imo + " dans la collection : " + this.RecupPosition(imo));
            imo = "IMO11111111";
            Console.WriteLine("Indice du navire " + imo + " dans la collection : " + this.RecupPosition(imo));


        }

        public void TesterRecupPositionV2()
        {
            Navire navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
            this.EnregistrerArrivee(navire);
            this.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
            this.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
            Console.WriteLine("Indice du navire " + navire.Imo + " dans la collection : " + this.RecupPosition(navire));
            Navire unAutreNavire = new Navire ("IMO8715871", "MSC PILAR");
            Console.WriteLine("Indice du navire " + unAutreNavire.Imo + " dans la collection : " + this.RecupPosition(unAutreNavire));
            unAutreNavire = new Navire("IMO8715871", "MSC PILAR", "Porte conteneurs", 52181);
            Console.WriteLine("Indice du navire " + unAutreNavire.Imo + " dans la collection : " + this.RecupPosition(unAutreNavire));
        }

        
    }
}
