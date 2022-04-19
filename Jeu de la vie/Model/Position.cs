using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    internal class Position
    {
        /// <summary>
        /// Propriété Position X dans la grille
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Propriété Position Y dans la grille
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Propriété Position X dans l'affichage (distance de gauche)
        /// </summary>
        public int XRelatif { get; private set; }

        /// <summary>
        /// Propriété Position Y dans l'affichage (distance du top)
        /// </summary>
        public int YRelatif { get; private set; }

        /// <summary>
        /// Constructeur de position
        /// </summary>
        /// <param name="x">Position x dans la grille systhème</param>
        /// <param name="y">Position y dans la grille systhème</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
            XRelatif = X * 40;
            YRelatif = Y * 40;
        }
    }
}
