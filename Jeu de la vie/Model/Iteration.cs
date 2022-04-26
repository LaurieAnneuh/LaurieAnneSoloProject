using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    internal class Iteration
    {
        public Grille Grille { get; set; }
        public Iteration(Grille grille)
        {
            Grille = grille;
        }

        public void FaireIteration()
        {

            foreach (Cellule cellule in Grille.laGrille)
            {
                if(cellule.EtatVie)
                {
                    if (cellule.nbVivanteAuTour < 2)
                    {
                        cellule.EtatVie = false;
                    }
                    else if (cellule.nbVivanteAuTour > 3)
                    {
                        cellule.EtatVie = false;
                    }
                }
                else
                {
                    if(cellule.nbVivanteAuTour == 3)
                    {
                        cellule.EtatVie = true;
                    }
                }
            }
        }
    }
}
