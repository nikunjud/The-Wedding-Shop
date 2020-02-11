using System;

namespace TWG_RoverPuzzle
{
    public class Rover
    {
        public Coordinates currentPostion { get; set; }
        public Coordinates direction { get; set; }

        /// <summary>
        /// Method to get the current direction in which rover is facing.
        /// </summary>
        /// <returns>N or R or W or S</returns>
        public String GetRoverCurrentDirection()
        {
            if (this.direction.xCord > 0)
            {
                return "E"; // for East
            }
            else if (this.direction.xCord < 0)
            {
                return "W"; // for West
            }
            else
            {
                if (this.direction.yCord > 0)
                {
                    return "N"; // for North
                }
                else
                {
                    return "S"; // for South
                }
            }
        }

        /// <summary>
        /// Method to set the direction and position of the rover.
        /// </summary>
        /// <param name="input">given position and directions like "1 2 N"</param>
        public void SetStartPostionAndDirection(String input)
        {
            string[] splitResult = input.Split(' ');
            this.currentPostion = new Coordinates(int.Parse(splitResult[0].ToString()), int.Parse(splitResult[1].ToString()));
            Coordinates dir = new Coordinates(0, 0);
            switch (Char.ToUpper(splitResult[2][0]))
            {
                case 'N': // for North
                    dir = new Coordinates(0, 1);
                    break;
                case 'W': // for West
                    dir = new Coordinates(-1, 0);
                    break;
                case 'S': // for South
                    dir = new Coordinates(0, -1);
                    break;
                case 'E': // for East
                    dir = new Coordinates(1, 0);
                    break;
            }

            this.direction = dir;
        }

        /// <summary>
        /// Method to move rover around as per given command.
        /// </summary>
        /// <param name="commands">Commands for rover.</param>
        /// <param name="maxCord">Maximum Cordinates of plateau.</param>
        public void MoveAround(String commands, Coordinates maxCord)
        {
            Coordinates minCord = new Coordinates(0, 0);
            foreach (char command in commands)
            {
                switch (Char.ToUpper(command))
                {
                    case 'R':
                        if (this.direction.xCord != 0)
                        {
                            this.direction.yCord -= this.direction.xCord;
                            this.direction.xCord -= this.direction.xCord;
                        }
                        else
                        {
                            this.direction.Exchange();
                        }
                        break;
                    case 'L':
                        if (this.direction.xCord == 0)
                        {
                            this.direction.xCord -= this.direction.yCord;
                            this.direction.yCord -= this.direction.yCord;
                        }
                        else
                        {
                            this.direction.Exchange();
                        }
                        break;
                    case 'M':
                        if (minCord.xCord <= this.currentPostion.xCord + this.direction.xCord && minCord.yCord <= this.currentPostion.yCord + this.direction.yCord &&
                          this.currentPostion.xCord + this.direction.xCord <= maxCord.xCord && this.currentPostion.yCord + this.direction.yCord <= maxCord.yCord)
                        {
                            this.currentPostion.xCord += this.direction.xCord;
                            this.currentPostion.yCord += this.direction.yCord;
                        }
                        break;
                }
            }
        }
    }
}