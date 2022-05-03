using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    internal class Position
    {
        //Position dans la grille
        public int X { get; set; }
        public int Y { get; set; }

        //Position dans la grille afficher
        public int XRelatif { get; private set; }
        public int YRelatif { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
            //placé d'après sa position dans la grille et la grandeur des cellules
            XRelatif = X * 20;
            YRelatif = Y * 20;
        }
    }
}
