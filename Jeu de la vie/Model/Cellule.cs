using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    internal class Cellule
    {
        //Attribut
        bool etatVie;

        /// <summary>
        /// L'objet Position de la cellule
        /// </summary>
        public Position Position { get; private set; }

        /// <summary>
        /// Propriété de l'état de vie de la cellule,
        /// Change la couleur dépendament de son état de vie
        /// </summary>
        public bool EtatVie 
        { 
            get { return etatVie; } 
            set { etatVie = value; 
                if (etatVie) { Couleur = "Red"; } 
                else { Couleur = "White"; }     
            } 
        }

        /// <summary>
        /// Propriété de la couleur d'affichage de la cellule
        /// </summary>
        public string Couleur { get; set; }

        /// <summary>
        /// Propriété du nombre de cellule vivante au tour (8) 
        /// </summary>
        public int nbVivanteAuTour { get; set; }

        /// <summary>
        /// Constructeur de cellule
        /// </summary>
        /// <param name="pos">la position dans la grille ou se trouve la cellule</param>
        /// <param name="Etat">Si elle est vivante ou non</param>
        public Cellule(Position pos, bool Etat)
        {
            Position = pos;
            EtatVie = Etat;
            nbVivanteAuTour = 0;
        }
    }
}
