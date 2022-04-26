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
        public List<Cellule> cellules;
        GererFichierTexte gererFichierTexte;
        public Grille(int laGrandeur)
        {
            grandeur = laGrandeur;
            laGrille= CréerGrille();
        }

        public Cellule[,] CréerGrille()
        {
            laGrille = new Cellule[grandeur, grandeur];
            cellules = new List<Cellule>();
            Cellule temp;
            for (int x = 0; x < grandeur; x++)
            {
                for(int y = 0; y < grandeur; y++)
                {
                    temp = new Cellule(new Position(x, y), false);
                    laGrille[x, y] = temp;
                    cellules.Add(temp);
                }
            }

            return laGrille;
        }

        public void viderGrille()
        {
            foreach (Cellule cellule in laGrille)
            {
                cellule.EtatVie = false;
            }
        }

        public void randomForm() 
        {
            Random random = new Random();
            int nombre = random.Next(grandeur*grandeur);
            for(int i = 0; i < nombre; i++)
            {
                int valeurX = random.Next(grandeur);
                int valeurY = random.Next(grandeur);
                laGrille[valeurX, valeurY].EtatVie = true;
            }
        }

        public void VérifierCellulesVivantes()
        {
            foreach(Cellule cellule in laGrille)
            {
                cellule.nbVivanteAuTour = 0;
                if (cellule.Position.X == 0 && cellule.Position.Y == 0)
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
