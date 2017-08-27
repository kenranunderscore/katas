namespace Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

    public class Day2 : DayWithInput<IEnumerable<string>>
    {
        public static readonly IReadOnlyDictionary<string, Vector> NumpadMapping
            = new Dictionary<string, Vector>
            {
                { "1", new Vector(-1, 1) },
                { "2", new Vector(0, 1) },
                { "3", new Vector(1, 1) },
                { "4", new Vector(-1, 0) },
                { "5", new Vector(0, 0) },
                { "6", new Vector(1, 0) },
                { "7", new Vector(-1, -1) },
                { "8", new Vector(0, -1) },
                { "9", new Vector(1, -1) }
            };

        public static readonly IReadOnlyDictionary<string, Vector> Part2Mapping
            = new Dictionary<string, Vector>
            {
                { "1", new Vector(0, 2) },
                { "2", new Vector(-1, 1) },
                { "3", new Vector(0, 1) },
                { "4", new Vector(1, 1) },
                { "5", new Vector(-2, 0) },
                { "6", new Vector(-1, 0) },
                { "7", new Vector(0, 0) },
                { "8", new Vector(1, 0) },
                { "9", new Vector(2, 0) },
                { "A", new Vector(-1, -1) },
                { "B", new Vector(0, -1) },
                { "C", new Vector(1, -1) },
                { "D", new Vector(0, -2) }
            };

        private static readonly IReadOnlyDictionary<char, Vector> DirectionMapping
            = new Dictionary<char, Vector>
            {
                { 'U', new Vector(0, 1) },
                { 'D', new Vector(0, -1) },
                { 'L', new Vector(-1, 0) },
                { 'R', new Vector(1, 0) }
            };

        public Day2(IEnumerable<string> lines) : base(lines) { }

        public string DecipherCode(IReadOnlyDictionary<string, Vector> mapping)
        {
            string currentCode = string.Empty;
            foreach (string line in input)
            {
                currentCode += CalculateCipherFromLine(line, string.IsNullOrEmpty(currentCode) ? "5" : currentCode, mapping);
            }

            return currentCode;
        }

        private static string CalculateCipherFromLine(string line, string currentCode, IReadOnlyDictionary<string, Vector> mapping)
        {
            Vector currentPosition = mapping[currentCode.Substring(currentCode.Length - 1)];

            for (int i = 0; i < line.Length; ++i)
            {
                Vector direction = DirectionMapping[line[i]];
                currentPosition = CalculateNextPositionWithinBoundaries(currentPosition, direction, mapping);
            }

            return mapping.First(x => x.Value == currentPosition).Key.ToString();
        }

        private static Vector CalculateNextPositionWithinBoundaries(Vector position, Vector direction, IReadOnlyDictionary<string, Vector> mapping)
        {
            Vector newPosition = position + direction;
            return mapping.Values.Contains(newPosition) ? newPosition : position;
        }
    }
}