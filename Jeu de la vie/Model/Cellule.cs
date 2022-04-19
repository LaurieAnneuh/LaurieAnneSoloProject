using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    internal class Cellule
    {
        public Position Position { get; private set; }
        public bool EtatVie { get; set; }
        public int nbVivanteAuTour { get; set; }
        public Cellule(Position pos, bool Etat)
        {
            Position = pos;
            EtatVie = Etat;
            nbVivanteAuTour = 0;
        }
    }
}
