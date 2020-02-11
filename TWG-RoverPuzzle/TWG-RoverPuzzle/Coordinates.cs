using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWG_RoverPuzzle
{
    public class Coordinates
    {
        /// <summary>
        /// X-Coordinate
        /// </summary>
        public int xCord { get; set; }

        /// <summary>
        /// Y-Coordinate
        /// </summary>
        public int yCord { get; set; }

        public Coordinates(int x, int y)
        {
            xCord = x;
            yCord = y;
        }

        /// <summary>
        /// Exchange the values.
        /// </summary>
        public void Exchange()
        {
            int temp = this.xCord;
            this.xCord = this.yCord;
            this.yCord = temp;
        }
    }
}
