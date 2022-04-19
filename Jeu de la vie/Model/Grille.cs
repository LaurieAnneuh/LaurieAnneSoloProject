using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    internal class Grille
    {
        public int grandeur { get; set; }
        public Cellule[,] laGrille;
        public Grille(int laGrandeur)
        {
            grandeur = laGrandeur;
            laGrille= CréerGrille();
        }

        public Cellule[,] CréerGrille()
        {
            Cellule[,]  grille = new Cellule[grandeur, grandeur];
            for (int x = 0; x < grandeur; x++)
            {
                for(int y = 0; y < grandeur; y++)
                {
                    grille[x, y] = new Cellule(new Position(x, y), false);
                }
            }

            return grille;
        }

        public void PremForm()
        {
            for(int i = 0; i < grandeur; i++)
            {
                laGrille[0, i].EtatVie = true;
                laGrille[i, 0].EtatVie = true;
                laGrille[grandeur-1, i].EtatVie = true;
                laGrille[i, grandeur-1].EtatVie = true;
            }
        }
        public void DeuForm()
        {
            for (int i = 0; i < grandeur; i++)
            {
                laGrille[0, i].EtatVie = true;
                laGrille[1, i].EtatVie = true;
                laGrille[2, i].EtatVie = true;
                laGrille[i, 1].EtatVie = true;
                laGrille[i, 0].EtatVie = true;
                laGrille[i, 2].EtatVie = true;
                laGrille[grandeur - 1, i].EtatVie = true;
                laGrille[i, grandeur - 1].EtatVie = true;
            }
        }
        public void TroiForm()
        {
            laGrille[1, 1].EtatVie = true;
            laGrille[2, 2].EtatVie = true;
            laGrille[2, 3].EtatVie = true;
            laGrille[3, 3].EtatVie = true;
            laGrille[4, 3].EtatVie = true;
            laGrille[4, 4].EtatVie = true;
            laGrille[5, 5].EtatVie = true;
            laGrille[6, 6].EtatVie = true; 
            laGrille[7, 7].EtatVie = true;
            laGrille[8, 8].EtatVie = true;
            laGrille[9, 9].EtatVie = true;
            laGrille[1, 3].EtatVie = true;
        }

        public void randomForm() 
        {
            Random random = new Random();
            int nombre = random.Next(grandeur*grandeur);
            for(int i = 0; i < nombre; i++)
            {
                int valeurX = random.Next(grandeur-1);
                int valeurY = random.Next(grandeur-1);
                laGrille[valeurX, valeurY].EtatVie = true;
            }
        }

        public void VérifierCellulesVivantes()
        {
            foreach(Cellule cellule in laGrille)
            {
                if(cellule.Position.X == 0 && cellule.Position.Y == 0)
                {
                    VerifierB(cellule);
                    VerifierCD(cellule);
                    VerifierDBD(cellule);
                }
                else if(cellule.Position.X == 0 && cellule.Position.Y == grandeur - 1)
                {
                    VerifierH(cellule);
                    VerifierDHD(cellule);
                    VerifierCD(cellule);
                }
                else if (cellule.Position.X == grandeur - 1 && cellule.Position.Y == 0)
                {
                    VerifierCG(cellule);
                    VerifierDBG(cellule);
                    VerifierB(cellule);
                }
                else if (cellule.Position.X == grandeur - 1 && cellule.Position.Y == grandeur - 1)
                {
                    VerifierH(cellule);
                    VerifierCG(cellule);
                    VerifierDHG(cellule);
                }
                else if(cellule.Position.X == 0 && cellule.Position.Y != 0 && cellule.Position.Y < grandeur -1)
                {
                    VerifierH(cellule);
                    VerifierDHD(cellule);
                    VerifierDBD(cellule);
                    VerifierCD(cellule);
                    VerifierB(cellule);
                }
                else if (cellule.Position.X != 0 && cellule.Position.Y == 0 && cellule.Position.X < grandeur - 1)
                {
                    VerifierCG(cellule);
                    VerifierDBG(cellule);
                    VerifierB(cellule);
                    VerifierDBD(cellule);
                    VerifierCD(cellule);
                }
                else if (cellule.Position.Y == grandeur - 1)
                {
                    VerifierCG(cellule);
                    VerifierCD(cellule);
                    VerifierH(cellule);
                    VerifierDHD(cellule);
                    VerifierDHG(cellule);
                }
                else if (cellule.Position.X == grandeur - 1)
                {
                    VerifierCG(cellule);
                    VerifierH(cellule);
                    VerifierDHG(cellule);
                    VerifierDBG(cellule);
                    VerifierB(cellule);
                }
                else
                {
                    VerifierCG(cellule);
                    VerifierCD(cellule);
                    VerifierH(cellule);
                    VerifierDHG(cellule);
                    VerifierDBG(cellule);
                    VerifierB(cellule);
                    VerifierDBD(cellule);
                    VerifierDHD(cellule);
                }

            }
        }

        #region Verifier
        void VerifierDBD(Cellule cellule)
        {
            //Celui en diagonale Bas Droit
            if (laGrille[cellule.Position.X + 1, cellule.Position.Y + 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }
        void VerifierB(Cellule cellule)
        {
            //Celui en Bas
            if (laGrille[cellule.Position.X, cellule.Position.Y + 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }
        void VerifierDHD(Cellule cellule)
        {
            //Celui en diagonale Haut Droit
            if (laGrille[cellule.Position.X + 1, cellule.Position.Y - 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }
        void VerifierH(Cellule cellule)
        {
            //Celui en haut
            if (laGrille[cellule.Position.X, cellule.Position.Y - 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }
        void VerifierCD(Cellule cellule)
        {
            //Celui à coté Droit
            if (laGrille[cellule.Position.X + 1, cellule.Position.Y].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        void VerifierCG(Cellule cellule)
        {
            //Celui à coté Gauche
            if (laGrille[cellule.Position.X - 1, cellule.Position.Y].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }
        void VerifierDBG(Cellule cellule)
        {
            //Celui à diagonale bas Gauche
            if (laGrille[cellule.Position.X - 1, cellule.Position.Y + 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }
        void VerifierDHG(Cellule cellule)
        {
            //Celui à diagonale haut Gauche
            if (laGrille[cellule.Position.X - 1, cellule.Position.Y - 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }
        #endregion

    }
}
