namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;

    public class Day1 : DayWithInput<string>
    {
        private static readonly Matrix right = new Matrix(0, -1, 1, 0, 0, 0);
        private static readonly Matrix left = new Matrix(0, 1, -1, 0, 0, 0);

        public Day1(string input) : base(input)
        {
        }

        public int Distance()
        {
            Vector currentDirection = new Vector(0, 1);
            Vector currentPosition = new Vector(0, 0);

            var commands =
                input
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => new Tuple<Matrix, int>(x[0] == 'R' ? right : left, int.Parse(x.Substring(1))));
            foreach (var command in commands)
            {
                currentDirection = AdvanceDirection(currentDirection, command);
                currentPosition += currentDirection * command.Item2;
            }

            return DistanceFromOrigin(currentPosition);
        }

        public int DistanceToFirstDoublyVisitedLocation()
        {
            Vector currentDirection = new Vector(0, 1);
            Vector currentPosition = new Vector(0, 0);
            HashSet<Vector> visitedLocations = new HashSet<Vector> { currentPosition };

            var commands =
                input
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => new Tuple<Matrix, int>(x[0] == 'R' ? right : left, int.Parse(x.Substring(1))));
            foreach (var command in commands)
            {
                currentDirection = AdvanceDirection(currentDirection, command);
                for (int i = 0; i < command.Item2; ++i)
                {
                    currentPosition += currentDirection;
                    if (visitedLocations.Contains(currentPosition))
                    {
                        return DistanceFromOrigin(currentPosition);
                    }

                    visitedLocations.Add(currentPosition);
                }
            }

            return DistanceFromOrigin(currentPosition);
        }

        private static Vector AdvanceDirection(Vector direction, Tuple<Matrix, int> command) => Vector.Multiply(direction, command.Item1);

        private static int DistanceFromOrigin(Vector position) => (int)(Math.Abs(position.X) + Math.Abs(position.Y));
    }
}