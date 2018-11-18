using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Location2D
    {
        public int row;
        public int col;
        public Location2D(int r = 0, int c = 0)
        {
            row = r;
            col = c;
        }
    }
}
