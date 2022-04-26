using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    internal class Cellule
    {
        bool etatVie;
        public Position Position { get; private set; }
        public bool EtatVie { get { return etatVie; } set { etatVie = value; if (etatVie) { Couleur = "Red"; } else { Couleur = "White"; } } }
        public int nbVivanteAuTour { get; set; }
        public Cellule(Position pos, bool Etat)
        {
            Position = pos;
            EtatVie = Etat;
            nbVivanteAuTour = 0;
        }
        public string Couleur { get; set; }
    }
}
