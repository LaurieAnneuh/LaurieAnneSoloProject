using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    internal class Iteration
    {
        //l'objet grille sur laquel on fait l'itération
        public Grille Grille { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="grille">l'objet grille sur laquel on fait l'itération</param>
        public Iteration(Grille grille)
        {
            Grille = grille;
        }

        /// <summary>
        /// Fait une itératio pour la grille
        /// </summary>
        public void FaireIteration()
        {
            //Pour chaque cellule
            foreach (Cellule cellule in Grille.laGrille)
            {
                //Si elle est en vie
                if(cellule.EtatVie)
                {
                    //Si elle a moins de 2 cellule vivante au tour elle meurt d'isolement
                    if (cellule.nbVivanteAuTour < 2)
                    {
                        cellule.EtatVie = false;
                    }
                    //Si elle a plus de 3 cellules vivante au tour elle meurt d'étouffement
                    else if (cellule.nbVivanteAuTour > 3)
                    {
                        cellule.EtatVie = false;
                    }
                }
                //si elle est morte
                else
                {
                    //Si elle a 3 cellules vivante au tour elle revie
                    if(cellule.nbVivanteAuTour == 3)
                    {
                        cellule.EtatVie = true;
                    }
                }
            }
        }
    }
}
