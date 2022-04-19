using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    internal class Grille
    {
        //attribut
        public int grandeur { get; set; }
        public Cellule[,] laGrille;
        public List<Cellule> cellules;

        /// <summary>
        /// Constructeur de l'objet grille
        /// </summary>
        /// <param name="laGrandeur">La hauteur et la largeur que la grille prend</param>
        public Grille(int laGrandeur)
        {
            grandeur = laGrandeur;
            laGrille= CréerGrille();
        }

        /// <summary>
        /// Génère la grille et les cellules qu'elle contient, avec leur position et leur état de vie mort.
        /// </summary>
        /// <returns>La grille construite de base</returns>
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
        /// Changer l'état de vie des cellules, pour qu'elles soient morte
        /// </summary>
        public void viderGrille()
        {
            foreach (Cellule cellule in laGrille)
            {
                cellule.EtatVie = false;
            }
        }

        #region Généré les formes
        /// <summary>
        /// Temporaire modifier la grille pour lui donner la forme 1.
        /// </summary>
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
        /// <summary>
        /// Temporaire modifier la grille pour lui donner la forme 2.
        /// </summary>
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
        /// <summary>
        /// Temporaire modifier la grille pour lui donner la forme 3.
        /// </summary>
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

        /// <summary>
        /// Généré une grille avec des cellules aléatoirement vivante 
        /// </summary>
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
        #endregion

        /// <summary>
        /// Vérifie pour chacune des cellules le nombre de cellule de voisine vivante dépendament sa position dans la grille
        /// </summary>
        public void VérifierCellulesVivantes()
        {
            foreach(Cellule cellule in laGrille)
            {
                //Vérifie si la cellule est un coin
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
                //verifie si la cellule est un coté
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
                //Une cellule normal
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

        #region Verifier Voisine
        /// <summary>
        /// Vérifie Cellule voisine en diagonale-Bas-Droit
        /// </summary>
        /// <param name="cellule">La cellule à vérifier</param>
        void VerifierDBD(Cellule cellule)
        {
            //Si l'état de vie de la voisine est vivante ajouter +1 au nombre de voisine vivante
            if (laGrille[cellule.Position.X + 1, cellule.Position.Y + 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie Cellule voisine en Bas
        /// </summary>
        /// <param name="cellule">La cellule à vérifier</param>
        void VerifierB(Cellule cellule)
        {
            //Si l'état de vie de la voisine est vivante ajouter +1 au nombre de voisine vivante
            if (laGrille[cellule.Position.X, cellule.Position.Y + 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie Cellule voisine en diagonale-Haut-Droit
        /// </summary>
        /// <param name="cellule">La cellule à vérifier</param>
        void VerifierDHD(Cellule cellule)
        {
            //Si l'état de vie de la voisine est vivante ajouter +1 au nombre de voisine vivante
            if (laGrille[cellule.Position.X + 1, cellule.Position.Y - 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie Cellule voisine en haut
        /// </summary>
        /// <param name="cellule">La cellule à vérifier</param>
        void VerifierH(Cellule cellule)
        {
            //Si l'état de vie de la voisine est vivante ajouter +1 au nombre de voisine vivante
            if (laGrille[cellule.Position.X, cellule.Position.Y - 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie Cellule voisine à Droite
        /// </summary>
        /// <param name="cellule">La cellule à vérifier</param>
        void VerifierCD(Cellule cellule)
        {
            //Si l'état de vie de la voisine est vivante ajouter +1 au nombre de voisine vivante
            if (laGrille[cellule.Position.X + 1, cellule.Position.Y].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie Cellule voisine à gauche
        /// </summary>
        /// <param name="cellule">La cellule à vérifier</param>
        void VerifierCG(Cellule cellule)
        {
            //Si l'état de vie de la voisine est vivante ajouter +1 au nombre de voisine vivante
            if (laGrille[cellule.Position.X - 1, cellule.Position.Y].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie Cellule voisine en diagonale-Bas-Gauche
        /// </summary>
        /// <param name="cellule">La cellule à vérifier</param>
        void VerifierDBG(Cellule cellule)
        {
            //Si l'état de vie de la voisine est vivante ajouter +1 au nombre de voisine vivante
            if (laGrille[cellule.Position.X - 1, cellule.Position.Y + 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }

        /// <summary>
        /// Vérifie Cellule voisine en diagonale-Haut-Gauche
        /// </summary>
        /// <param name="cellule">La cellule à vérifier</param>
        void VerifierDHG(Cellule cellule)
        {
            //Si l'état de vie de la voisine est vivante ajouter +1 au nombre de voisine vivante
            if (laGrille[cellule.Position.X - 1, cellule.Position.Y - 1].EtatVie)
            {
                cellule.nbVivanteAuTour = cellule.nbVivanteAuTour + 1;
            }
        }
        #endregion

    }
}
