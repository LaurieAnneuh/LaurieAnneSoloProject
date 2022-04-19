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

        /// <summary>
        /// Constructeur d'itération
        /// </summary>
        /// <param name="grille">Grille utiliser</param>
        public Iteration(Grille grille)
        {
            Grille = grille;
        }

        /// <summary>
        /// Vérifie pour chaque cellule si son état de vie change dépendament du nombre de cellules voisines vivantes
        /// </summary>
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
