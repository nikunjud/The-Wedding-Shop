using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TWG_RoverPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            IList<string> input = new List<string>();
            IList<Rover> roversData = new List<Rover>();
            Console.WriteLine("Please input data and type 'result' to see the output.");
            while ((line = Console.ReadLine()).ToLower() != "result")
            {
                if (!String.IsNullOrEmpty(line.Trim()))
                {
                    input.Add(Regex.Replace(line.Trim(), @"\s+", " "));
                }
            }

            if (input.Count > 1) // Assumption: Min 1 rover is deployed.
            {
                int xCoordinate;
                int yCoordinate;
                string[] splitResult = input[0].Split(' ');
                if (splitResult.Length == 2
                    && int.TryParse(splitResult[0], out xCoordinate)
                    && int.TryParse(splitResult[1], out yCoordinate) && (xCoordinate > 0 || yCoordinate > 0))
                {
                    Coordinates maxPosition = new Coordinates(xCoordinate, yCoordinate);
                    for (int i = 1; i < input.Count; i = i + 2)
                    {
                        Rover rr = new Rover();
                        if (IsValidInitialPositionAndDirection(input[i], maxPosition))
                        {
                            rr.SetStartPostionAndDirection(input[i]);
                            if ((i + 1) < input.Count && input[i + 1] != null && input[i + 1].Length > 0)
                            {
                                rr.MoveAround(input[i + 1], maxPosition);
                            }

                            roversData.Add(rr);
                        }

                    }
                }
            }

            foreach (var rover in roversData)
            {
                Console.WriteLine(rover.currentPostion.xCord + " " + rover.currentPostion.yCord + " " + rover.GetRoverCurrentDirection());
            }

            Console.WriteLine("Press Any Key To Exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Method to verify if the initial given position and direction to rover are correct or not.
        /// </summary>
        /// <param name="input">Input position and direction</param>
        /// <param name="maxPosition">Max Position coordinates of the plateau.</param>
        /// <returns>true if valid otherwise false.</returns>
        private static bool IsValidInitialPositionAndDirection(string input, Coordinates maxPosition)
        {
            bool isValid = false;
            string[] splitResult = input.Split(' ');
            int xCoordinate;
            int yCoordinate;
            if (splitResult.Length == 3
                && int.TryParse(splitResult[0], out xCoordinate)
                && int.TryParse(splitResult[1], out yCoordinate)
                && xCoordinate >= 0 && yCoordinate >= 0
                && xCoordinate <= maxPosition.xCord && yCoordinate <= maxPosition.yCord
                && (splitResult[2]).ToUpper().All(x => x == 'N' || x == 'W' || x == 'E' || x == 'S')
                )
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
