using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Location
    {
        public int Col { get; set; }
        public int Row { get; set; }

        public Location()
        {
                
        }
        public Location(int col,int row)
        {
            this.Col = col;
            this.Row = row; 
        }
    }
}
