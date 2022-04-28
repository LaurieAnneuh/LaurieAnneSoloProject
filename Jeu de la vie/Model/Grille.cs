using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    internal class Grille
    {
        #region Attribut
        public int grandeur { get; set; }
        public Cellule[,] laGrille;
        public List<Cellule> cellules;
        GererFichierTexte gererFichierTexte;
        #endregion

        /// <summary>
        /// Constructeur de Grille
        /// </summary>
        /// <param name="laGrandeur">la grandeur de la grille à généré</param>
        public Grille(int laGrandeur)
        {
            grandeur = laGrandeur;
            laGrille= CréerGrille();
        }

        /// <summary>
        /// Crée l'array de la grille
        /// </summary>
        /// <returns>une array de cellule </returns>
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

        /// <summary>
        /// Met toute les cellules en état de vie false (mort)
        /// </summary>
        public void viderGrille()
        {
            foreach (Cellule cellule in laGrille)
            {
                cellule.EtatVie = false;
            }
        }

        /// <summary>
        /// Génère une grille aléatoire
        /// </summary>
        public void randomForm() 
        {
            Random random = new Random();
            //d'après le nombre maximum de cellule
            int nombre = random.Next(grandeur*grandeur);

            //d'après une position aléatoire
            for(int i = 0; i < nombre; i++)
            {
                int valeurX = random.Next(grandeur);
                int valeurY = random.Next(grandeur);
                laGrille[valeurX, valeurY].EtatVie = true; // elle devient vivante
            }
        }

        /// <summary>
        /// Vérifie d'après sa position dans la grille le nombre de voisine vivante
        /// Elle ajoute au compteur dans la cellule pour chaque cellule
        /// </summary>
        public void VérifierCellulesVivantes()
        {
            foreach(Cellule cellule in laGrille)
            {

                //S'il s'agit d'un coin de la grille, 
                //elle aura maximum 3 voisine
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

                //S'il s'agit d'un côté de la grille, 
                //elle aura maximum 5 voisine
                else if (cellule.Position.X == 0 && cellule.Position.Y != 0 && cellule.Position.Y < grandeur -1)
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

                //S'il s'agit ni d'un coin, ni d'un côté de la grille, 
                //elle aura maximum 8 voisine
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
        /// <summary>
        /// Vérifie la cellule voisine de en diagonale bas droite
        /// </summary>
        /// <param name="cellule">la cellule d'un la voisine est vérifier</param>
        void VerifierDBD(Cellule cellule)
        {
            //Celui en diagonale Bas Droit
            if (laGrille[cellule.Position.X + 1, cellule.Position.Y + 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }
        /// <summary>
        /// Vérifie la cellule voisine de en bas
        /// </summary>
        /// <param name="cellule">la cellule d'un la voisine est vérifier</param>
        void VerifierB(Cellule cellule)
        {
            //Celui en Bas
            if (laGrille[cellule.Position.X, cellule.Position.Y + 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie la cellule voisine de en diagonale haut droite
        /// </summary>
        /// <param name="cellule">la cellule d'un la voisine est vérifier</param>
        void VerifierDHD(Cellule cellule)
        {
            //Celui en diagonale Haut Droit
            if (laGrille[cellule.Position.X + 1, cellule.Position.Y - 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie la cellule voisine en haut
        /// </summary>
        /// <param name="cellule">la cellule d'un la voisine est vérifier</param>
        void VerifierH(Cellule cellule)
        {
            //Celui en haut
            if (laGrille[cellule.Position.X, cellule.Position.Y - 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie la cellule voisine de droit
        /// </summary>
        /// <param name="cellule">la cellule d'un la voisine est vérifier</param>
        void VerifierCD(Cellule cellule)
        {
            //Celui à coté Droit
            if (laGrille[cellule.Position.X + 1, cellule.Position.Y].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie la cellule voisine de gauche
        /// </summary>
        /// <param name="cellule">la cellule d'un la voisine est vérifier</param>
        void VerifierCG(Cellule cellule)
        {
            //Celui à coté Gauche
            if (laGrille[cellule.Position.X - 1, cellule.Position.Y].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie la cellule voisine de en diagonale bas gauche
        /// </summary>
        /// <param name="cellule">la cellule d'un la voisine est vérifier</param>
        void VerifierDBG(Cellule cellule)
        {
            //Celui à diagonale bas Gauche
            if (laGrille[cellule.Position.X - 1, cellule.Position.Y + 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie la cellule voisine de en diagonale haut gauche
        /// </summary>
        /// <param name="cellule">la cellule d'un la voisine est vérifier</param>
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
