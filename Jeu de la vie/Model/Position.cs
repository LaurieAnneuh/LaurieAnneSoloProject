using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    internal class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int XRelatif { get; private set; }
        public int YRelatif { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
            XRelatif = X * 40;
            YRelatif = Y * 40;
        }
    }
}
